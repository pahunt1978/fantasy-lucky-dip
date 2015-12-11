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
    public class DisciplineData : IDisciplineData
    {
        public List<Discipline> GetList(long eventId)
        {
            var parameters = new
            {
                EventId = eventId
            };

            using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString))
            {
                return sqlConnection.Query<Discipline>("Discipline_GetList", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}