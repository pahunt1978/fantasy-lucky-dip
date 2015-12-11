using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using FantasyLuckyDip.BusinessLogicInterfaces;
using FantasyLuckyDip.DataTransferObjects;
using FantasyLuckyDip.Website.Models;

namespace FantasyLuckyDip.Website.Controllers
{
    public class ContestantController : Controller
    {
        private const long EventId = 1;

        private readonly IContestantBusinessLogic contestantBusinessLogic;
        private readonly IAthleteBusinessLogic athleteBusinessLogic;

        public ContestantController(IContestantBusinessLogic contestantBusinessLogic, IAthleteBusinessLogic athleteBusinessLogic)
        {
            this.contestantBusinessLogic = contestantBusinessLogic;
            this.athleteBusinessLogic = athleteBusinessLogic;
        }

        public ActionResult Add()
        {
            var model = this.GetContestantAddModel();
            return this.View(model);
        }        

        [HttpPost]
        public ActionResult Add(ContestantAddInputModel model)
        {
            var contestant = new Contestant
            {
                TwitterHandle = model.TwitterHandle,
                Name = model.Name,
                MaleTrackAthleteId = model.MaleTrackAthleteId,
                MaleFieldAthleteId = model.MaleFieldAthleteId,
                FemaleTrackAthleteId = model.FemaleTrackAthleteId,
                FemaleFieldAthleteId = model.FemaleFieldAthleteId,
                CountryId = model.CountryId
            };

            this.contestantBusinessLogic.AddContestant(contestant, EventId);

            return this.RedirectToAction("Add");
        }

        private ContestantAddModel GetContestantAddModel()
        {
            var athletes = this.athleteBusinessLogic.GetList(EventId);

            return new ContestantAddModel
            {
                MaleTrackAthletes = athletes.Where(x => x.DisciplineType == DisciplineType.Track && x.Gender == Gender.Male).Select(x => new SelectListItem { Value = x.Id.ToString(CultureInfo.CurrentCulture), Text = x.FullName }).ToList(),
                MaleFieldAthletes = athletes.Where(x => x.DisciplineType == DisciplineType.Field && x.Gender == Gender.Male).Select(x => new SelectListItem { Value = x.Id.ToString(CultureInfo.CurrentCulture), Text = x.FullName }).ToList(),
                FemaleTrackAthletes = athletes.Where(x => x.DisciplineType == DisciplineType.Track && x.Gender == Gender.Female).Select(x => new SelectListItem { Value = x.Id.ToString(CultureInfo.CurrentCulture), Text = x.FullName }).ToList(),
                FemaleFieldAthletes = athletes.Where(x => x.DisciplineType == DisciplineType.Field && x.Gender == Gender.Female).Select(x => new SelectListItem { Value = x.Id.ToString(CultureInfo.CurrentCulture), Text = x.FullName }).ToList(),
                Countries = new List<SelectListItem> { new SelectListItem { Value = "1", Text = "Jamaica" } }
            };
        }
    }
}