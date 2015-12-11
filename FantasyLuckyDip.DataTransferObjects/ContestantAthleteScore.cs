namespace FantasyLuckyDip.DataTransferObjects
{
    public class ContestantAthleteScore
    {
        public long ContestantId { get; set; }

        public int MaleTrackAthletePoints { get; set; }

        public int MaleFieldAthletePoints { get; set; }

        public int FemaleTrackAthletePoints { get; set; }

        public int FemaleFieldAthletePoints { get; set; }

        public int CountryId { get; set; }        
    }
}