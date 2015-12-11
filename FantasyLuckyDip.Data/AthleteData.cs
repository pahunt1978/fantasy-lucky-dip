using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using FantasyLuckyDip.Data.Interfaces;
using FantasyLuckyDip.DataInterfaces;
using FantasyLuckyDip.DataTransferObjects;

namespace FantasyLuckyDip.Data
{
    public class AthleteData : IAthleteData
    {
        private readonly IDataHelper dataHelper;

        public AthleteData(IDataHelper dataHelper)
        {
            this.dataHelper = dataHelper;
        }

        public List<Athlete> GetList(long eventId)
        {
            var parameters = new
            {
                EventId = eventId
            };

            using (var sqlConnection = new SqlConnection(this.dataHelper.ConnectionString))
            {
                List<Athlete> result;

                using (var multi = sqlConnection.QueryMultiple("GetEventAthletes", parameters, commandType: CommandType.StoredProcedure))
                {
                    result = multi.Read<Athlete>().ToList();
                    var eventAthleteDisciplines = multi.Read<EventAthleteDiscipline>().ToList();

                    var eventAthleteDisciplinesByAthleteId = eventAthleteDisciplines.ToLookup(x => x.AthleteId);

                    foreach (var athlete in result)
                    {
                        athlete.Disciplines.AddRange(eventAthleteDisciplinesByAthleteId[athlete.Id].Select(x => new EventAthleteDiscipline { DisciplineId = x.DisciplineId, Place = x.Place }));                        
                    }
                }

                return result;
            }
        }

        public List<EventAthleteResult> GetResults(long eventId)
        {
            var parameters = new
            {
                EventId = eventId
            };

            using (var sqlConnection = new SqlConnection(this.dataHelper.ConnectionString))
            {
                return sqlConnection.Query<EventAthleteResult>("GetAthleteResults", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}