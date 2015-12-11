using System.Collections.Generic;
using System.Web.Mvc;

namespace FantasyLuckyDip.Website.Models
{
    public class ContestantAddModel
    {
        public string TwitterHandle { get; set; }

        public string Name { get; set; }

        public long MaleTrackAthleteId { get; set; }

        public List<SelectListItem> MaleTrackAthletes { get; set; }

        public long MaleFieldAthleteId { get; set; }

        public List<SelectListItem> MaleFieldAthletes { get; set; }

        public long FemaleTrackAthleteId { get; set; }

        public List<SelectListItem> FemaleTrackAthletes { get; set; }

        public long FemaleFieldAthleteId { get; set; }

        public List<SelectListItem> FemaleFieldAthletes { get; set; }

        public long CountryId { get; set; }

        public List<SelectListItem> Countries { get; set; }
    }
}