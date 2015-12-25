namespace FantasyLuckyDip.DataTransferObjects
{
    public interface IContestantEventTeam
    {
        long ContestantId { get; set; }

        string TwitterHandle { get; set; }

        string Name { get; set; }
    }
}