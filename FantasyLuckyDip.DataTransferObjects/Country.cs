using System.Collections.Generic;

namespace FantasyLuckyDip.DataTransferObjects
{
    public class Country
    {
        public Country()
        {
            this.Disciplines = new List<EventCountryDiscipline>();
        }

        public long Id { get; set; }

        public string Name { get; set; }

        public string IsoCode { get; set; }

        public List<EventCountryDiscipline> Disciplines { get; private set; }    
    }
}