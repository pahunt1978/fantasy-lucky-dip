using FantasyLuckyDip.BusinessLogicInterfaces;
using FantasyLuckyDip.DataInterfaces;
using FantasyLuckyDip.DataTransferObjects;

namespace FantasyLuckyDip.BusinessLogic
{
    public class ContestantBusinessLogic : IContestantBusinessLogic
    {
        private readonly IContestantData contestantData;

        public ContestantBusinessLogic(IContestantData contestantData)
        {
            this.contestantData = contestantData;
        }

        public void AddContestant(Contestant contestant, long eventId)
        {
            this.contestantData.AddContestant(contestant, eventId);
        }
    }
}
