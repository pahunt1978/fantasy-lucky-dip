using System.Web.Mvc;
using System.Web.UI;
using FantasyLuckyDip.BusinessLogicInterfaces;

namespace FantasyLuckyDip.Website.Controllers
{
    public class ImageController : Controller
    {
        private readonly ITwitterBusinessLogic twitterBusinessLogic;

        public ImageController(ITwitterBusinessLogic twitterBusinessLogic)
        {        
            this.twitterBusinessLogic = twitterBusinessLogic;
        }

        [OutputCache(Duration = 86400, VaryByParam = "twitterHandle", Location = OutputCacheLocation.ServerAndClient)]
        public ActionResult GetTwitterProfileImage(long contestantId, string twitterHandle)
        {
            return this.File(this.twitterBusinessLogic.GetProfileImage(twitterHandle), "image/jpeg");            
        }

        [OutputCache(Duration = int.MaxValue, Location = OutputCacheLocation.ServerAndClient)]
        public ActionResult GetNoPictureAvailableImage()
        {
            return this.Redirect("http://www.iaaf.org/Content/img/ui/profile-img-missing.png?v=1267328004");
        }
    }
}