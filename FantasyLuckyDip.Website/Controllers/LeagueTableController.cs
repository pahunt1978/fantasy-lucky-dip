using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FantasyLuckyDip.BusinessLogicInterfaces;
using FantasyLuckyDip.DataTransferObjects;
using FantasyLuckyDip.Website.Models;

namespace FantasyLuckyDip.Website.Controllers
{
    public class LeagueTableController : Controller
    {
        private const long EventId = 1;
        
        private readonly IEventBusinessLogic eventBusinessLogic;
        private readonly IAthleteBusinessLogic athleteBusinessLogic;
        private readonly ICountryBusinessLogic countryBusinessLogic;
        private readonly IDisciplineBusinessLogic disciplineBusinessLogic;

        public LeagueTableController(IEventBusinessLogic eventBusinessLogic, IAthleteBusinessLogic athleteBusinessLogic, ICountryBusinessLogic countryBusinessLogic, IDisciplineBusinessLogic disciplineBusinessLogic)
        {
            this.eventBusinessLogic = eventBusinessLogic;
            this.athleteBusinessLogic = athleteBusinessLogic;
            this.countryBusinessLogic = countryBusinessLogic;
            this.disciplineBusinessLogic = disciplineBusinessLogic;
        }

        public ActionResult Index()
        {
            var model = this.GetModel();
            return this.View(model);
        }

        private static void SetCountries(LeagueTableModel model, IEnumerable<Country> countries, IReadOnlyCollection<Athlete> athletes, IReadOnlyCollection<EventAthleteResult> athleteResults, IReadOnlyCollection<Discipline> disciplines)
        {
            foreach (var country in countries)
            {                                                
                var leagueTableCountryResultModel = new LeagueTableCountryResultModel
                {
                    Id = country.Id,
                    Name = country.Name,
                    IsoCode = country.IsoCode
                };

                var countryAthleteResults = athleteResults.Where(x => x.AthleteCountryId == country.Id);

                foreach (var countryAthleteResult in countryAthleteResults.Where(x => x.Place >= 1 && x.Place <= 3))
                {
                    var athlete = athletes.FirstOrDefault(x => x.Id == countryAthleteResult.AthleteId);

                    leagueTableCountryResultModel.Medals.Add(new LeagueTableCountryMedalModel
                    {
                        AthleteSurname = athlete.Surname,
                        DisciplineName = disciplines.First(x => x.Id == countryAthleteResult.DisciplineId).Name                        
                    });                    
                }                

                foreach (var countryDiscipline in country.Disciplines)
                {
                    var discipline = disciplines.FirstOrDefault(y => y.Id == countryDiscipline.DisciplineId);

                    leagueTableCountryResultModel.Disciplines.Add(new LeagueTableDisciplineModel
                    {
                        Name = discipline.Name,
                        Gender = discipline.Gender,    
                        ResultsEntered = discipline.ResultsEntered,
                        Place = countryDiscipline.Place,                        
                    });
                }

                model.Countries.Add(leagueTableCountryResultModel);
            }
        }

        private static void SetAthletes(LeagueTableModel model, IEnumerable<Athlete> athletes, List<EventAthleteResult> athleteResults, List<Discipline> disciplines)
        {
            foreach (var athlete in athletes)
            {
                model.Athletes.Add(new LeagueTableAthleteModel
                {
                    Id = athlete.Id,
                    Forename = athlete.Forename,
                    Surname = athlete.Surname,
                    CountryId = athlete.CountryId,
                    IaafId = athlete.IaafId,                    
                    Points = athleteResults.Where(x => x.AthleteId == athlete.Id).Sum(x => x.Points),
                    Disciplines = athlete.Disciplines.Select(x => new LeagueTableDisciplineModel
                    {
                        Name = disciplines.First(y => y.Id == x.DisciplineId).Name,
                        Place = x.Place,
                        ResultsEntered = disciplines.First(y => y.Id == x.DisciplineId).ResultsEntered
                        /*FinalDateTime = new ZonedDateTime(new Instant(x.FinalDateTime), DateTimeZoneProviders.Tzdb[x.TimeZoneId]),
                        TimeZoneId = x.TimeZoneId*/
                    }).ToList()
                });
            }
        }

        private static void SetContestants(LeagueTableModel model, IEnumerable<ContestantEventTeam> teams, List<Athlete> athletes, List<Country> countries, List<EventAthleteResult> athleteResults, List<EventCountryResult> countryResults)
        {
            foreach (var team in teams)
            {
                var maleTrackAthlete = athletes.FirstOrDefault(x => x.Id == team.MaleTrackAthleteId);
                var maleFieldAthlete = athletes.FirstOrDefault(x => x.Id == team.MaleFieldAthleteId);
                var femaleTrackAthlete = athletes.FirstOrDefault(x => x.Id == team.FemaleTrackAthleteId);
                var femaleFieldAthlete = athletes.FirstOrDefault(x => x.Id == team.FemaleFieldAthleteId);
                var country = countries.FirstOrDefault(x => x.Id == team.CountryId);
                var teamAthleteResults = athleteResults.Where(x => x.AthleteId == team.MaleTrackAthleteId || x.AthleteId == team.MaleFieldAthleteId || x.AthleteId == team.FemaleTrackAthleteId || x.AthleteId == team.FemaleFieldAthleteId).ToList();
                var teamAthleteCountryResults = athleteResults.Where(x => x.AthleteCountryId == team.CountryId).ToList();
                var athleteCountryPoints = teamAthleteCountryResults.Count(x => x.Place >= 1 && x.Place <= 3);
                var teamCountryResults = countryResults.Where(x => x.CountryId == country.Id);
                var countryPoints = teamCountryResults.Count(x => x.Place >= 1 && x.Place <= 3);

                model.Contestants.Add(new LeagueTableContestantModel
                {
                    Id = team.ContestantId,
                    Position = 1,
                    TwitterHandle = team.TwitterHandle,
                    Name = team.Name,
                    TotalPoints = teamAthleteResults.Sum(x => x.Points) + athleteCountryPoints + countryPoints,
                    MaleTrackAthlete = new LeagueTableAthleteModel
                    {
                        Id = team.MaleTrackAthleteId,                        
                        Surname = maleTrackAthlete.Surname,
                        IaafId = maleTrackAthlete.IaafId,                        
                        Points = teamAthleteResults.Where(x => x.AthleteId == team.MaleTrackAthleteId).Sum(x => x.Points),
                        Disciplines = maleTrackAthlete.Disciplines.Select(x => new LeagueTableDisciplineModel
                        {                        
                            Place = x.Place
                        }).ToList()
                    },
                    MaleFieldAthlete = new LeagueTableAthleteModel
                    {
                        Id = team.MaleFieldAthleteId,                        
                        Surname = maleFieldAthlete.Surname,
                        IaafId = maleFieldAthlete.IaafId,
                        Points = teamAthleteResults.Where(x => x.AthleteId == team.MaleFieldAthleteId).Sum(x => x.Points),
                        Disciplines = maleFieldAthlete.Disciplines.Select(x => new LeagueTableDisciplineModel
                        {
                            Place = x.Place
                        }).ToList()                        
                    },
                    FemaleTrackAthlete = new LeagueTableAthleteModel
                    {
                        Id = team.FemaleTrackAthleteId,
                        Surname = femaleTrackAthlete.Surname,
                        IaafId = femaleTrackAthlete.IaafId,
                        Points = teamAthleteResults.Where(x => x.AthleteId == team.FemaleTrackAthleteId).Sum(x => x.Points),
                        Disciplines = femaleTrackAthlete.Disciplines.Select(x => new LeagueTableDisciplineModel
                        {
                            Place = x.Place
                        }).ToList()                        
                    },
                    FemaleFieldAthlete = new LeagueTableAthleteModel
                    {
                        Id = team.FemaleFieldAthleteId,
                        Surname = femaleFieldAthlete.Surname,
                        IaafId = femaleFieldAthlete.IaafId,
                        Points = teamAthleteResults.Where(x => x.AthleteId == team.FemaleFieldAthleteId).Sum(x => x.Points),
                        Disciplines = femaleFieldAthlete.Disciplines.Select(x => new LeagueTableDisciplineModel
                        {
                            Place = x.Place
                        }).ToList() 
                    },
                    Country = new LeagueTableCountryModel
                    {
                        Id = team.CountryId,
                        Name = country.Name,
                        IsoCode = country.IsoCode,
                        Points = athleteCountryPoints + countryPoints
                    }
                });
            }
        }

        private LeagueTableModel GetModel()
        {
            var teams = this.eventBusinessLogic.GetTeams(EventId);            
            var athletes = this.athleteBusinessLogic.GetList(EventId);
            var athleteResults = this.athleteBusinessLogic.GetResults(EventId);
            var countries = this.countryBusinessLogic.GetList(EventId);
            var countryResults = this.countryBusinessLogic.GetResults(EventId);
            var disciplines = this.disciplineBusinessLogic.GetList(EventId);

            var model = new LeagueTableModel();

            SetContestants(model, teams, athletes, countries, athleteResults, countryResults);
            SetAthletes(model, athletes, athleteResults, disciplines);
            SetCountries(model, countries, athletes, athleteResults, disciplines);

            return model;
        }        
    }
}