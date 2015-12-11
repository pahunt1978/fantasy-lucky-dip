using System.Collections.Generic;

namespace FantasyLuckyDip.DataTransferObjects
{
    public class Athlete
    {
        public Athlete()
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

        public List<EventAthleteDiscipline> Disciplines { get; private set; }        

        public string FullName => $"{this.Forename} {this.Surname}";
    }
}