using System.Collections.Generic;

namespace FantasyLuckyDip.Website.Models
{
    public class LeagueTableAthleteModel
    {
        public LeagueTableAthleteModel()
        {
            this.Disciplines = new List<LeagueTableDisciplineModel>();
        }

        public long Id { get; set; }

        public string Forename { get; set; }

        public string Surname { get; set; }

        public long IaafId { get; set; }

        public long CountryId { get; set; }

        public int Points { get; set; }        

        public List<LeagueTableDisciplineModel> Disciplines { get; set; }

        public string FullName => $"{this.Forename} {this.Surname}";

        public override bool Equals(object obj)
        {
            var comparison = obj as LeagueTableAthleteModel;
            return comparison != null && this.Id.Equals(comparison.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}