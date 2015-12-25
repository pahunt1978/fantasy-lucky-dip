using System.Collections.Generic;
using System.Linq;

namespace FantasyLuckyDip.DataTransferObjects
{
    public class EventAthlete
    {
        public EventAthlete()
        {
            this.Disciplines = new List<EventAthleteDiscipline>();
        }

        public long Id { get; set; }

        public string Forename { get; set; }

        public string Surname { get; set; }

        public DisciplineType DisciplineType { get; set; }

        public Gender Gender { get; set; }

        public long IaafId { get; set; }

        public long CountryId { get; set; }

        public List<EventAthleteDiscipline> Disciplines { get; }        

        public string FullName => $"{this.Forename} {this.Surname}";

        public int Points
        {
            get
            {
                return this.Disciplines.Sum(x => x.Points);
            }
        }
    }
}