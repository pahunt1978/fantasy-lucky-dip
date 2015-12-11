using System.Collections.Generic;
using FantasyLuckyDip.BusinessLogicInterfaces;
using FantasyLuckyDip.DataInterfaces;
using FantasyLuckyDip.DataTransferObjects;

namespace FantasyLuckyDip.BusinessLogic
{
    public class AthleteBusinessLogic : IAthleteBusinessLogic
    {
        private readonly IAthleteData athleteData;

        public AthleteBusinessLogic(IAthleteData athleteData)
        {
            this.athleteData = athleteData;
        }

        public List<Athlete> GetList(long eventId)
        {
            return this.athleteData.GetList(eventId);
        }

        public List<EventAthleteResult> GetResults(long eventId)
        {
            return this.athleteData.GetResults(eventId);
        }
    }
}