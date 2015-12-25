using System.Web.Mvc;
using FantasyLuckyDip.BusinessLogicInterfaces;

namespace FantasyLuckyDip.Website.Controllers
{
    public class LayoutController : Controller
    {
        private readonly IEventBusinessLogic eventBusinessLogic;

        public LayoutController(IEventBusinessLogic eventBusinessLogic)
        {
            this.eventBusinessLogic = eventBusinessLogic;
        }

        public ActionResult GetEventDetails(long id)
        {
            const string HtmlTemplate = "<div id=\"{0}\" class=\"hidden\">{1}</div>";

            var eventDetail = this.eventBusinessLogic.Get(id);

            var html = string.Format(HtmlTemplate, "PrimaryHeadingData", eventDetail.PrimaryHeading);
            html += string.Format(HtmlTemplate, "SecondaryHeadingData", eventDetail.SecondaryHeading);
            html += string.Format(HtmlTemplate, "TimeZoneData", eventDetail.TimeZone);
            html += string.Format(HtmlTemplate, "TimetableLinkData", eventDetail.TimetableUrl);
            html += string.Format(HtmlTemplate, "LocationData", eventDetail.Location);

            return this.Content(html);
        }        
    }
}