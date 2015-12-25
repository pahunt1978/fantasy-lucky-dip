using System.Collections.Generic;
using FantasyLuckyDip.DataTransferObjects;

namespace FantasyLuckyDip.Website.Models
{
    public class LeagueTableWorldChampionshipsModel : ILeagueTableModel
    {
        public LeagueTableWorldChampionshipsModel()
        {            
            this.Contestants = new List<LeagueTableWorldChampionshipContestantModel>();            
            this.Countries = new List<LeagueTableCountryResultModel>();
        }        

        public List<LeagueTableWorldChampionshipContestantModel> Contestants { get; private set; }

        public List<LeagueTableCountryResultModel> Countries { get; private set; }

        public long EventId { get; set; }

        public EventType Type { get; set; }
    }
}