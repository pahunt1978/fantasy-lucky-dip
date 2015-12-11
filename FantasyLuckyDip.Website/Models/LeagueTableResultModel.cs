namespace FantasyLuckyDip.Website.Models
{
    public class LeagueTableResultModel
    {
        public long AthleteId { get; set; }

        public long AthleteCountryId { get; set; }

        public long DisciplineId { get; set; }

        public string DisciplineName { get; set; }

        public int Place { get; set; }

        public string PlaceDisplay
        {
            get
            {
                switch (this.Place)
                {
                    case 1:
                        return "1st";
                    case 2:
                        return "2nd";
                    case 3:
                        return "3rd";
                    case 4:
                        return "4th";
                    case 5:
                        return "5th";
                    case 6:
                        return "6th";
                    case 7:
                        return "7th";
                    case 8:
                        return "8th";
                    default:
                        return "-";
                }
            }
        }
    }
}