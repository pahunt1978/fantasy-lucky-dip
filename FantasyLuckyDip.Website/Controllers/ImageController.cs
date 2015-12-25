using System.IO;
using System.Net;
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

        ////[OutputCache(Duration = 86400, VaryByParam = "twitterHandle", Location = OutputCacheLocation.ServerAndClient)]
        public ActionResult GetTwitterProfileImage(long contestantId, string twitterHandle)
        {
            return MvcApplication.ShowImages ? this.File(this.twitterBusinessLogic.GetProfileImage(twitterHandle), "image/jpeg") : null;
        }

        ////[OutputCache(Duration = int.MaxValue, Location = OutputCacheLocation.ServerAndClient)]
        public ActionResult GetNoPictureAvailableImage()
        {
            return MvcApplication.ShowImages ? this.File(Download($"http://www.iaaf.org/Content/img/ui/profile-img-missing.png?v=1267328004"), "image/jpeg") : null;
            
        }

        ////[OutputCache(Duration = int.MaxValue, VaryByParam = "countryIsoCode", Location = OutputCacheLocation.ServerAndClient)]
        public ActionResult GetCountryFlag(string countryIsoCode)
        {
            if (MvcApplication.ShowImages)
            {
                var image = Download($"http://flags.fmcdn.net/data/flags/normal/{countryIsoCode.ToLowerInvariant()}.png");
                return image != null ? this.File(image, "image/jpeg") : GetNoPictureAvailableImage();
            }

            return null;
        }

        ////[OutputCache(Duration = int.MaxValue, VaryByParam = "athleteId", Location = OutputCacheLocation.ServerAndClient)]
        public ActionResult GetAthleteProfileImage(long athleteId)
        {
            if (MvcApplication.ShowImages)
            {
                var image = Download($"https://iaafmedia.s3.amazonaws.com/athletes/{athleteId}.jpg");
                return image != null ? this.File(image, "image/jpeg") : GetNoPictureAvailableImage();
            }

            return null;            
        }

        private static MemoryStream Download(string url)
        {
            using (var webClient = new WebClient())
            {
                try
                {                    
                    return new MemoryStream(webClient.DownloadData(url));
                }
                catch (WebException)
                {
                    return null;
                }                                               
            }
        }
    }
}