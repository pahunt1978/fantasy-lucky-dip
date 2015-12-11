using System.Collections.Generic;
using FantasyLuckyDip.DataTransferObjects;

namespace FantasyLuckyDip.BusinessLogicInterfaces
{
    public interface IAthleteBusinessLogic
    {
        List<Athlete> GetList(long eventId);

        List<EventAthleteResult> GetResults(long eventId);
    }
}