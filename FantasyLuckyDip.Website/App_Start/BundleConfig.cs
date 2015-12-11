using System.Web.Optimization;

namespace FantasyLuckyDip.Website
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            const string JQueryVersion = "2.1.4";
            const string JQueryUiVersion = "1.11.4";

            var jqueryCdnBaseUrl = $"//ajax.googleapis.com/ajax/libs/jquery/{JQueryVersion}/";
            var jqueryUiCdnBaseUrl = $"//ajax.googleapis.com/ajax/libs/jqueryui/{JQueryUiVersion}/";            

            bundles.UseCdn = true;

            /***** CSS Bundles *****/
            bundles.Add(new StyleBundle("~/Bundles/MainDesktopStyles")
                .Include("~/Content/main-desktop.css"));

            bundles.Add(new StyleBundle("~/Bundles/MainMobileStyles")
                .Include("~/Content/main-mobile.css"));

            bundles.Add(new StyleBundle("~/Content/Themes/base/JQueryUiCssBundle")
                .IncludeDirectory("~/Content/Themes/base/", "*.css"));                

            /***** JavaScript Bundles *****/
            bundles.Add(new ScriptBundle("~/Bundles/MainScripts")
                .Include("~/Scripts/moment.js")
                .Include("~/Scripts/moment-timezone-with-data-2010-2020.js")
                .Include("~/Scripts/layout.js"));

            bundles.Add(new ScriptBundle("~/Bundles/JQueryScripts", $"{jqueryCdnBaseUrl}{"jquery.min.js"}")
                .Include($"~/Scripts/jquery-{JQueryVersion}.js"));

            bundles.Add(new ScriptBundle("~/Bundles/JQueryUiScripts", $"{jqueryUiCdnBaseUrl}{"jquery-ui.min.js"}")
                .Include($"~/Scripts/jquery-ui-{JQueryUiVersion}.js"));                        
        }
    }
}