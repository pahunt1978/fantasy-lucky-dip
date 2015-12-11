using System.Collections.Generic;
using FantasyLuckyDip.DataTransferObjects;

namespace FantasyLuckyDip.BusinessLogicInterfaces
{
    public interface IEventBusinessLogic
    {
        Event Get(long eventId);

        List<ContestantEventTeam> GetTeams(long eventId);        
    }
}