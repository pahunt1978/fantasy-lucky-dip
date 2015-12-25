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
        private readonly IEventBusinessLogic eventBusinessLogic;                

        public LeagueTableController(IEventBusinessLogic eventBusinessLogic)
        {
            this.eventBusinessLogic = eventBusinessLogic;                        
        }

        public ActionResult Index(string url)
        {
            var model = this.GetModel(url);
            return this.View(model);
        }        

        private static void SetContestants(LeagueTableGotzisModel model, IEnumerable<Contestant> contestants, IEnumerable<ContestantEventAthlete> contestantEventAthletes, List<EventAthlete> eventAthletes)
        {
            foreach (var contestant in contestants)
            {
                var contestantModel = model.Contestants.FirstOrDefault(x => x.Id == contestant.Id);

                if (contestantModel == null)
                {
                    contestantModel = new LeagueTableGotzisContestantModel();
                    model.Contestants.Add(contestantModel);
                }

                var filteredContestantEventAthletes = contestantEventAthletes.Where(x => x.ContestantId == contestant.Id);

                contestantModel.Id = contestant.Id;
                contestantModel.Position = 1;
                contestantModel.TwitterHandle = contestant.TwitterHandle;
                contestantModel.Name = contestant.Name;

                foreach (var contestantEventAthlete in filteredContestantEventAthletes)
                {
                    var eventAthlete = eventAthletes.FirstOrDefault(x => x.Id == contestantEventAthlete.AthleteId);

                    var leagueTableAthleteModel = new LeagueTableAthleteModel
                    {
                        Id = eventAthlete.Id,
                        Surname = eventAthlete.Surname,
                        CountryId = eventAthlete.CountryId,
                        Forename = eventAthlete.Forename,
                        IaafId = eventAthlete.IaafId,
                        Points = eventAthlete.Points,
                        Disciplines = eventAthlete.Disciplines.Select(x => new LeagueTableDisciplineModel
                        {
                            Name = x.Name,
                            Place = x.Place,
                            ResultsEntered = x.ResultsEntered
                        }).ToList()
                    };

                    switch (contestantEventAthlete.EventAthleteType)
                    {
                        case EventAthleteType.Decathlete1:
                            contestantModel.Decathlete1 = leagueTableAthleteModel;
                            break;
                        case EventAthleteType.Decathlete2:
                            contestantModel.Decathlete2 = leagueTableAthleteModel;
                            break;
                        case EventAthleteType.Heptathlete1:
                            contestantModel.Heptahlete1 = leagueTableAthleteModel;
                            break;
                        case EventAthleteType.Heptathlete2:
                            contestantModel.Heptahlete2 = leagueTableAthleteModel;
                            break;
                    }
                }

                contestantModel.TotalPoints = contestantModel.Decathlete1.Points + contestantModel.Decathlete2.Points + contestantModel.Heptahlete1.Points + (contestantModel.Heptahlete2?.Points ?? 0);
            }
        }

        private static void SetContestants(LeagueTableWorldChampionshipsModel model, IEnumerable<Contestant> contestants, IReadOnlyCollection<ContestantEventAthlete> contestantEventAthletes, IReadOnlyCollection<EventAthlete> eventAthletes, IReadOnlyCollection<ContestantEventCountry> contestantEventCountries, IReadOnlyCollection<EventCountry> eventCountries)
        {
            foreach (var contestant in contestants)
            {
                var contestantModel = model.Contestants.FirstOrDefault(x => x.Id == contestant.Id);

                if (contestantModel == null)
                {
                    contestantModel = new LeagueTableWorldChampionshipContestantModel();
                    model.Contestants.Add(contestantModel);
                }

                var filteredContestantEventAthletes = contestantEventAthletes.Where(x => x.ContestantId == contestant.Id);
                
                contestantModel.Id = contestant.Id;
                contestantModel.Position = 1;
                contestantModel.TwitterHandle = contestant.TwitterHandle;
                contestantModel.Name = contestant.Name;                

                foreach (var contestantEventAthlete in filteredContestantEventAthletes)
                {
                    var eventAthlete = eventAthletes.FirstOrDefault(x => x.Id == contestantEventAthlete.AthleteId);
                    
                    var leagueTableAthleteModel = new LeagueTableAthleteModel
                    {
                        Id = eventAthlete.Id,
                        Surname = eventAthlete.Surname,
                        CountryId = eventAthlete.CountryId,
                        Forename = eventAthlete.Forename,
                        IaafId = eventAthlete.IaafId,                        
                        Points = eventAthlete.Points,
                        Disciplines = eventAthlete.Disciplines.Select(x => new LeagueTableDisciplineModel
                        {              
                            Name = x.Name,
                            Place = x.Place,
                            ResultsEntered = x.ResultsEntered
                        }).ToList()
                    };

                    switch (contestantEventAthlete.EventAthleteType)
                    {
                        case EventAthleteType.MaleTrack:
                            contestantModel.MaleTrackAthlete = leagueTableAthleteModel;
                            break;
                        case EventAthleteType.MaleField:
                            contestantModel.MaleFieldAthlete = leagueTableAthleteModel;
                            break;
                        case EventAthleteType.FemaleTrack:
                            contestantModel.FemaleTrackAthlete = leagueTableAthleteModel;
                            break;
                        case EventAthleteType.FemaleField:
                            contestantModel.FemaleFieldAthlete = leagueTableAthleteModel;
                            break;
                    }
                }

                var contestantEventCountry = contestantEventCountries.FirstOrDefault(x => x.ContestantId == contestant.Id);
                var eventCountry = eventCountries.FirstOrDefault(x => x.Id == contestantEventCountry.CountryId);
                
                if (eventCountry != null)
                {                    
                    contestantModel.Country = new LeagueTableCountryResultModel
                    {
                        Id = eventCountry.Id,
                        Name = eventCountry.Name,
                        IsoCode = eventCountry.IsoCode,
                        Points = eventCountry.Points,
                        Disciplines = eventCountry.Disciplines.Select(x => new LeagueTableDisciplineModel
                        {
                            Name = x.Name,
                            Place = x.Place,
                            ResultsEntered = x.ResultsEntered
                        }).ToList()
                    };

                    foreach (var eventAthlete in eventAthletes.Where(x => x.CountryId == eventCountry.Id))
                    {
                        foreach (var discipline in eventAthlete.Disciplines.Where(x => x.Place >= 1 && x.Place <= 3))
                        {
                            contestantModel.Country.Medals.Add(new LeagueTableCountryMedalModel
                            {
                                AthleteSurname = eventAthlete.Surname,
                                DisciplineName = discipline.Name
                            });
                        }                        
                    }                    
                }

                contestantModel.TotalPoints = contestantModel.MaleTrackAthlete.Points + contestantModel.MaleFieldAthlete.Points + contestantModel.FemaleTrackAthlete.Points + contestantModel.FemaleFieldAthlete.Points + contestantModel.Country.Points;
            }                                               
        }        

        private ILeagueTableModel GetModel(string url)
        {
            var @event = this.eventBusinessLogic.Get(url);
            var contestants = this.eventBusinessLogic.GetContestants(@event.Id);
            var contestantEventAthletes = this.eventBusinessLogic.GetContestantAthletes(@event.Id);
            var contestantEventCountries = this.eventBusinessLogic.GetContestantCountries(@event.Id);
            var eventAthletes = this.eventBusinessLogic.GetAthletes(@event.Id);
            var eventCountries = this.eventBusinessLogic.GetCountries(@event.Id);            
            ILeagueTableModel model;

            if (@event.Type == EventType.WorldChampionships)
            {                
                model = new LeagueTableWorldChampionshipsModel();
                SetContestants((LeagueTableWorldChampionshipsModel)model, contestants, contestantEventAthletes, eventAthletes, contestantEventCountries, eventCountries);                                
            }
            else
            {
                model = new LeagueTableGotzisModel();
                SetContestants((LeagueTableGotzisModel)model, contestants, contestantEventAthletes, eventAthletes);                
            }
            
            model.EventId = @event.Id;
            model.Type = @event.Type;

            return model;
        }        
    }
}