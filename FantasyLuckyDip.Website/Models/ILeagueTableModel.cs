using FantasyLuckyDip.DataTransferObjects;

namespace FantasyLuckyDip.Website.Models
{
    public interface ILeagueTableModel
    {
        long EventId { get; set; }

        EventType Type { get; set; }
    }
}