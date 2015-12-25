using System.Diagnostics;

namespace FantasyLuckyDip.DataTransferObjects
{
    public class Event
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string PrimaryHeading { get; set; }

        public string SecondaryHeading { get; set; }

        public string TimeZone { get; set; }

        public string TimetableUrl { get; set; }

        public string Location { get; set; }

        public EventType Type { get; set; }
    }
}