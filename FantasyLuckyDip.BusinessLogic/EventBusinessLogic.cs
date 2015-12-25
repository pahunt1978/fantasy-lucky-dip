using System.Collections.Generic;
using System.Linq;
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

        public Event Get(string url)
        {
            return this.eventData.Get(url);
        }

        public List<ContestantEventAthlete> GetContestantAthletes(long eventId)
        {
            return this.eventData.GetContestantAthletes(eventId);
        }

        public List<ContestantEventCountry> GetContestantCountries(long eventId)
        {
            return this.eventData.GetContestantCountries(eventId);
        }

        public List<EventAthlete> GetAthletes(long eventId)
        {
            var eventAthletes = this.eventData.GetAthletes(eventId);
            var @event = this.Get(eventId);

            if (@event.Type == EventType.WorldChampionships)
            {
                foreach (var eventAthlete in eventAthletes)
                {
                    foreach (var discipline in eventAthlete.Disciplines)
                    {
                        switch (discipline.Place)
                        {
                            case 1:
                                discipline.Points += 8;
                                break;
                            case 2:
                                discipline.Points += 7;
                                break;
                            case 3:
                                discipline.Points += 6;
                                break;
                            case 4:
                                discipline.Points += 5;
                                break;
                            case 5:
                                discipline.Points += 4;
                                break;
                            case 6:
                                discipline.Points += 3;
                                break;
                            case 7:
                                discipline.Points += 2;
                                break;
                            case 8:
                                discipline.Points += 1;
                                break;
                        }
                    }
                }
            }
            else if (@event.Type == EventType.Gotzis)
            {
                foreach (var eventAthlete in eventAthletes)
                {
                    foreach (var discipline in eventAthlete.Disciplines)
                    {
                        switch (discipline.Place)
                        {
                            case 1:
                                discipline.Points += 10;
                                break;
                            case 2:
                                discipline.Points += 9;
                                break;
                            case 3:
                                discipline.Points += 8;
                                break;
                            case 4:
                                discipline.Points += 7;
                                break;
                            case 5:
                                discipline.Points += 6;
                                break;
                            case 6:
                                discipline.Points += 5;
                                break;
                            case 7:
                                discipline.Points += 4;
                                break;
                            case 8:
                                discipline.Points += 3;
                                break;
                            case 9:
                                discipline.Points += 2;
                                break;
                            case 10:
                                discipline.Points += 1;
                                break;
                        }
                    }
                }
            }

            return eventAthletes;
        }

        public List<EventCountry> GetCountries(long eventId)
        {
            var eventCountries = this.eventData.GetCountries(eventId);
            var eventAthletes = this.GetAthletes(eventId);
            var @event = this.Get(eventId);

            if (@event.Type == EventType.WorldChampionships)
            {
                foreach (var eventCountry in eventCountries)
                {
                    eventCountry.Points += eventCountry.Disciplines.Count(x => x.Place >= 1 && x.Place <= 3);
                    eventCountry.Points += eventAthletes.Where(x => x.CountryId == eventCountry.Id).SelectMany(x => x.Disciplines).Count(x => x.Place >= 1 && x.Place <= 3);                    
                }
            }

            return eventCountries;
        }

        public List<Contestant> GetContestants(long eventId)
        {
            return this.eventData.GetContestants(eventId);
        }
    }
}