using FantasyLuckyDip.DataTransferObjects;
using NodaTime;

namespace FantasyLuckyDip.Website.Models
{
    public class LeagueTableDisciplineModel
    {
        public string Name { get; set; }

        public int? Place { get; set; }

        public Gender Gender { get; set; }        

        public ZonedDateTime FinalDateTime { get; set; }

        public string TimeZoneId { get; set; }

        public bool ResultsEntered { get; set; }

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
                        return this.ResultsEntered ? "Outside top 8" : "?";
                }                
            }
        }

        public string CountryPlaceDisplay
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
                    default:
                        return this.ResultsEntered ? "Outside top 3" : "?";
                }
            }
        }
    }
}