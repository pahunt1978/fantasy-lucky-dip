namespace FantasyLuckyDip.DataTransferObjects
{
    public class Discipline
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public Gender Gender { get; set; }

        public bool ResultsEntered { get; set; }
    }
}