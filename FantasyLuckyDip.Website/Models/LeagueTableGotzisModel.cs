using System.Collections.Generic;
using FantasyLuckyDip.DataTransferObjects;

namespace FantasyLuckyDip.Website.Models
{
    public class LeagueTableGotzisModel : ILeagueTableModel
    {
        public LeagueTableGotzisModel()
        {
            this.Contestants = new List<LeagueTableGotzisContestantModel>();            
        }

        public List<LeagueTableGotzisContestantModel> Contestants { get; private set; }

        public long EventId { get; set; }

        public EventType Type { get; set; }
    }
}