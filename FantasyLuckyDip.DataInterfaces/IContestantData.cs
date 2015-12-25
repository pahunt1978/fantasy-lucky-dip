using FantasyLuckyDip.DataTransferObjects;

namespace FantasyLuckyDip.DataInterfaces
{
    public interface IContestantData
    {
        void AddContestant(Contestant contestant, long eventId);
    }
}