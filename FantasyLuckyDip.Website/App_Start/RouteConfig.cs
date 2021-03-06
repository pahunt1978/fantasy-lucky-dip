﻿using System.Web.Mvc;
using System.Web.Routing;

namespace FantasyLuckyDip.Website
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute("LeagueTable", "LeagueTable/{url}", new { controller = "LeagueTable", action = "Index", url = UrlParameter.Optional });
            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "LeagueTable", action = "Index", id = UrlParameter.Optional });           
        }
    }
}
