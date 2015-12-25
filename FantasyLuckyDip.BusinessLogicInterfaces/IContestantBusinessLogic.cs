using FantasyLuckyDip.DataTransferObjects;

namespace FantasyLuckyDip.BusinessLogicInterfaces
{
    public interface IContestantBusinessLogic
    {
        void AddContestant(Contestant contestant, long eventId);
    }
}
