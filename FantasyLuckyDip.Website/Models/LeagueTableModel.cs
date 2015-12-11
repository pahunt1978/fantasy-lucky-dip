using System.Collections.Generic;

namespace FantasyLuckyDip.Website.Models
{
    public class LeagueTableModel
    {
        public LeagueTableModel()
        {            
            this.Contestants = new List<LeagueTableContestantModel>();
            this.Athletes = new List<LeagueTableAthleteModel>();
            this.Countries = new List<LeagueTableCountryResultModel>();
        }        

        public List<LeagueTableContestantModel> Contestants { get; private set; }

        public List<LeagueTableAthleteModel> Athletes { get; private set; }

        public List<LeagueTableCountryResultModel> Countries { get; private set; }        
    }
}