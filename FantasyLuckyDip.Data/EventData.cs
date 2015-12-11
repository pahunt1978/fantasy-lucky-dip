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
    public class EventData : IEventData
    {
        public Event Get(long eventId)
        {
            var parameters = new
            {
                EventId = eventId
            };

            using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString))
            {
                return sqlConnection.Query<Event>("GetEvent", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public List<ContestantEventTeam> GetTeams(long eventId)
        {
            var parameters = new
            {
                EventId = eventId
            };

            using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString))
            {
                return sqlConnection.Query<ContestantEventTeam>("GetContestantEventTeams", parameters, commandType: CommandType.StoredProcedure).ToList();
            }            
        }        
    }
}