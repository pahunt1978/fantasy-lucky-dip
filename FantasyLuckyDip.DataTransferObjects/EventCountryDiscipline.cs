namespace FantasyLuckyDip.DataTransferObjects
{
    public class EventCountryDiscipline
    {
        public long CountryId { get; set; }

        public long DisciplineId { get; set; }

        public int Place { get; set; }

        public int Points { get; set; }

        public string Name { get; set; }

        public bool ResultsEntered { get; set; }
    }
}