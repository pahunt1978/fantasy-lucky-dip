using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FantasyLuckyDip.DependencyInjection;
using FantasyLuckyDip.Website.Framework;

namespace FantasyLuckyDip.Website
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = StructureMapCoreSetup.Configure();
            DependencyResolver.SetResolver(new StructureMapDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RouteConfig.RegisterRoutes(RouteTable.Routes);            
        }
    }
}
