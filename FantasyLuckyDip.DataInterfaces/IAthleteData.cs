using System.Collections.Generic;
using FantasyLuckyDip.DataTransferObjects;

namespace FantasyLuckyDip.DataInterfaces
{
    public interface IAthleteData
    {
        List<Athlete> GetList(long eventId);

        List<EventAthleteResult> GetResults(long eventId);
    }
}