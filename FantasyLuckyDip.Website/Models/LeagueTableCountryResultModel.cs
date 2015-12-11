using System.Collections.Generic;

namespace FantasyLuckyDip.Website.Models
{
    public class LeagueTableCountryResultModel
    {
        public LeagueTableCountryResultModel()
        {
            this.Medals = new List<LeagueTableCountryMedalModel>();
            this.Disciplines = new List<LeagueTableDisciplineModel>();
        }

        public long Id { get; set; }

        public string Name { get; set; }

        public string IsoCode { get; set; }

        public List<LeagueTableCountryMedalModel> Medals { get; private set; }

        public List<LeagueTableDisciplineModel> Disciplines { get; private set; }
    }
}