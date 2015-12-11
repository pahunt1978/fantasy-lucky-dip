using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using FantasyLuckyDip.DataInterfaces;
using FantasyLuckyDip.DataTransferObjects;

namespace FantasyLuckyDip.Data
{
    public class ContestantData : IContestantData
    {        
        public void AddContestant(Contestant contestant, long eventId)
        {
            var parameters = new
            {
                EventId = eventId,
                TwitterHandle = contestant.TwitterHandle,
                Name = contestant.Name,
                MaleTrackAthleteId = contestant.MaleTrackAthleteId,
                MaleFieldAthleteId = contestant.MaleFieldAthleteId,
                FemaleTrackAthleteId = contestant.FemaleTrackAthleteId,
                FemaleFieldAthleteId = contestant.FemaleFieldAthleteId,
                CountryId = contestant.CountryId
            };

            using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString))
            {
                sqlConnection.Execute("AddContestant", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public byte[] GetImage(long contestantId)
        {
            var parameters = new
            {
                ContestantId = contestantId
            };

            using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString))
            {                
                return sqlConnection.Query<byte[]>("Contestant_GetImage", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();                
            }
        }
    }
}