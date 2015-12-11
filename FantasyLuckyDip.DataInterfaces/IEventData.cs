using System.Collections.Generic;
using FantasyLuckyDip.DataTransferObjects;

namespace FantasyLuckyDip.DataInterfaces
{
    public interface IEventData
    {
        Event Get(long eventId);

        List<ContestantEventTeam> GetTeams(long eventId);        
    }
}