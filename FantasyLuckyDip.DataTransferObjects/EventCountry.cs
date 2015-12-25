using System.Collections.Generic;

namespace FantasyLuckyDip.DataTransferObjects
{
    public class EventCountry
    {
        public EventCountry()
        {
            this.Disciplines = new List<EventCountryDiscipline>();            
        }

        public long Id { get; set; }

        public string Name { get; set; }

        public string IsoCode { get; set; }

        public int Points { get; set; }

        public List<EventCountryDiscipline> Disciplines { get; }        
    }
}