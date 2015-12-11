namespace FantasyLuckyDip.Website.Models
{
    public class ContestantAddInputModel
    {
        public string TwitterHandle { get; set; }

        public string Name { get; set; }

        public long MaleTrackAthleteId { get; set; }        

        public long MaleFieldAthleteId { get; set; }        

        public long FemaleTrackAthleteId { get; set; }        

        public long FemaleFieldAthleteId { get; set; }

        public long CountryId { get; set; }
    }
}