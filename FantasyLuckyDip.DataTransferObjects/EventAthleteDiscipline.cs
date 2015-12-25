namespace FantasyLuckyDip.DataTransferObjects
{
    public class EventAthleteDiscipline
    {
        public long AthleteId { get; set; }

        public long DisciplineId { get; set; }

        public int Place { get; set; }

        public int Points { get; set; }

        public string Name { get; set; }

        public bool ResultsEntered { get; set; }
    }
}