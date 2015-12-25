using FantasyLuckyDip.DataInterfaces;
using FantasyLuckyDip.DataTransferObjects;

namespace FantasyLuckyDip.Data
{
    public class ContestantData : IContestantData
    {        
        public void AddContestant(Contestant contestant, long eventId)
        {
            /*var parameters = new
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
                sqlConnection.Execute("Contestant_Add", parameters, commandType: CommandType.StoredProcedure);
            }*/
        }
    }
}