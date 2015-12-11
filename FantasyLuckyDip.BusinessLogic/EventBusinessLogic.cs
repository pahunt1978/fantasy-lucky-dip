using System.Collections.Generic;
using FantasyLuckyDip.BusinessLogicInterfaces;
using FantasyLuckyDip.DataInterfaces;
using FantasyLuckyDip.DataTransferObjects;

namespace FantasyLuckyDip.BusinessLogic
{
    public class EventBusinessLogic : IEventBusinessLogic
    {
        private readonly IEventData eventData;

        public EventBusinessLogic(IEventData eventData)
        {
            this.eventData = eventData;
        }

        public Event Get(long eventId)
        {
            return this.eventData.Get(eventId);
        }

        public List<ContestantEventTeam> GetTeams(long eventId)
        {
            return this.eventData.GetTeams(eventId);
        }        
    }
}