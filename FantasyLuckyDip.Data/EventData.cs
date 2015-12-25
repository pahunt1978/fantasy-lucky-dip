using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using FantasyLuckyDip.Data.Interfaces;
using FantasyLuckyDip.DataInterfaces;
using FantasyLuckyDip.DataTransferObjects;

namespace FantasyLuckyDip.Data
{
    public class EventData : IEventData
    {
        private readonly IDataHelper dataHelper;

        public EventData(IDataHelper dataHelper)
        {
            this.dataHelper = dataHelper;
        }

        public Event Get(long eventId)
        {
            var parameters = new
            {
                EventId = eventId
            };

            using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString))
            {
                return sqlConnection.Query<Event>("Event_GetById", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public Event Get(string url)
        {
            var parameters = new
            {
                Url = url
            };

            using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString))
            {
                return sqlConnection.Query<Event>("Event_GetByUrl", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public List<Contestant> GetContestants(long eventId)
        {
            var parameters = new
            {
                EventId = eventId
            };

            using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString))
            {
                return sqlConnection.Query<Contestant>("Event_GetContestants", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<ContestantEventAthlete> GetContestantAthletes(long eventId)
        {
            var parameters = new
            {
                EventId = eventId
            };

            using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString))
            {
                return sqlConnection.Query<ContestantEventAthlete>("Event_GetContestantAthletes", parameters, commandType: CommandType.StoredProcedure).ToList();
            }            
        }

        public List<ContestantEventCountry> GetContestantCountries(long eventId)
        {
            var parameters = new
            {
                EventId = eventId
            };

            using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString))
            {
                return sqlConnection.Query<ContestantEventCountry>("Event_GetContestantCountries", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }        

        public List<EventAthlete> GetAthletes(long eventId)
        {
            var parameters = new
            {
                EventId = eventId
            };

            using (var sqlConnection = new SqlConnection(this.dataHelper.ConnectionString))
            {
                List<EventAthlete> result;

                using (var multi = sqlConnection.QueryMultiple("Event_GetAthletes", parameters, commandType: CommandType.StoredProcedure))
                {
                    result = multi.Read<EventAthlete>().ToList();
                    var eventAthleteDisciplines = multi.Read<EventAthleteDiscipline>().ToList();

                    var eventAthleteDisciplinesByAthleteId = eventAthleteDisciplines.ToLookup(x => x.AthleteId);

                    foreach (var athlete in result)
                    {
                        athlete.Disciplines.AddRange(eventAthleteDisciplinesByAthleteId[athlete.Id].Select(x => new EventAthleteDiscipline { DisciplineId = x.DisciplineId, Place = x.Place, Name = x.Name, ResultsEntered = x.ResultsEntered, AthleteId = x.AthleteId }));
                    }
                }

                return result;
            }            
        }

        public List<EventCountry> GetCountries(long eventId)
        {
            var parameters = new
            {
                EventId = eventId
            };

            using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString))
            {
                List<EventCountry> result;

                using (var multi = sqlConnection.QueryMultiple("Event_GetCountries", parameters, commandType: CommandType.StoredProcedure))
                {
                    result = multi.Read<EventCountry>().ToList();
                    var eventCountryDisciplines = multi.Read<EventCountryDiscipline>().ToList();

                    var eventCountryDisciplinesByCountryId = eventCountryDisciplines.ToLookup(x => x.CountryId);

                    foreach (var country in result)
                    {
                        country.Disciplines.AddRange(eventCountryDisciplinesByCountryId[country.Id].Select(x => new EventCountryDiscipline { DisciplineId = x.DisciplineId, Place = x.Place, Name = x.Name, ResultsEntered = x.ResultsEntered, CountryId = x.CountryId }));
                    }
                }

                return result;
            }
        }
    }
}