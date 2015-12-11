using System.Collections.Generic;

namespace FantasyLuckyDip.Website.Models
{
    public class LeagueTableCountryModel
    {
        public LeagueTableCountryModel()
        {
            this.Results = new List<LeagueTableCountryResultModel>();
        }

        public long Id { get; set; }

        public string Name { get; set; }

        public string IsoCode { get; set; }

        public int Points { get; set; }

        public List<LeagueTableCountryResultModel> Results { get; set; }
    }
}