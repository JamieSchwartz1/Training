using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            //routes.MapRoute(
            //    "MoviesByReleaseDate",                                        //name
            //    "movies/released/{year}/{month}",                             //URL pattern plus 2 parameters in {}
            //    new { controller = "Movies", action = "ByReleaseDate" },      //defaults
            //    new { year = @"\d{4}", month = @"\d{2}" });                   //year must have 4 digits and month must have 2 digits

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
