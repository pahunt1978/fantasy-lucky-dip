using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using FantasyLuckyDip.DataInterfaces;
using FantasyLuckyDip.DataTransferObjects;

namespace FantasyLuckyDip.Data
{
    public class CountryData : ICountryData
    {
        public List<Country> GetList(long eventId)
        {
            var parameters = new
            {
                EventId = eventId
            };

            using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString))
            {
                List<Country> result;

                using (var multi = sqlConnection.QueryMultiple("Country_GetList", parameters, commandType: CommandType.StoredProcedure))
                {
                    result = multi.Read<Country>().ToList();
                    var eventAthleteDisciplines = multi.Read<EventCountryDiscipline>().ToList();

                    var eventCountryDisciplinesByCountryId = eventAthleteDisciplines.ToLookup(x => x.CountryId);

                    foreach (var country in result)
                    {
                        country.Disciplines.AddRange(eventCountryDisciplinesByCountryId[country.Id].Select(x => new EventCountryDiscipline { DisciplineId = x.DisciplineId, Place = x.Place }));
                    }
                }

                return result;
            }            
        }

        public List<EventCountryResult> GetResults(long eventId)
        {
            var parameters = new
            {
                EventId = eventId
            };

            using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString))
            {
                return sqlConnection.Query<EventCountryResult>("Country_GetResults", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}