using System.Collections.Generic;
using FantasyLuckyDip.DataTransferObjects;

namespace FantasyLuckyDip.DataInterfaces
{
    public interface IEventData
    {
        Event Get(long eventId);

        Event Get(string url);

        List<Contestant> GetContestants(long eventId);

        List<ContestantEventAthlete> GetContestantAthletes(long eventId);

        List<ContestantEventCountry> GetContestantCountries(long eventId);        

        List<EventAthlete> GetAthletes(long eventId);

        List<EventCountry> GetCountries(long eventId);
    }
}