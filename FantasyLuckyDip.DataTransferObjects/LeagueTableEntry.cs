namespace FantasyLuckyDip.DataTransferObjects
{
    public class LeagueTableEntry
    {
        public long ContestantId { get; set; }        

        public int MaleTrackAthletePoints { get; set; }

        public int MaleFieldAthletePoints { get; set; }

        public int FemaleTrackAthletePoints { get; set; }

        public int FemaleFieldAthletePoints { get; set; }

        public int CountryPoints { get; set; }

        public int TotalPoints => this.MaleTrackAthletePoints + this.MaleFieldAthletePoints + this.FemaleTrackAthletePoints + this.FemaleFieldAthletePoints + this.CountryPoints;
    }
}