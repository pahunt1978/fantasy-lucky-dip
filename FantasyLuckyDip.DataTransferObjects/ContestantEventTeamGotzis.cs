namespace FantasyLuckyDip.DataTransferObjects
{
    public class ContestantEventTeamGotzis : IContestantEventTeam
    {
        public long ContestantId { get; set; }

        public string TwitterHandle { get; set; }

        public string Name { get; set; }

        public long AthleteId { get; set; }        
    }
}