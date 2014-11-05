namespace Shop.Net.Web
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
             name: "FriendlyUrls",
             url: "products/{friendlyUrl}",
             defaults: new { controller = "Product", action = "ByFriendlyUrl", friendlyUrl = UrlParameter.Optional });

            routes.MapRoute(
               name: "Default", 
               url: "{controller}/{action}/{id}", 
               defaults: new { controller = "Pages", action = "Index", id = UrlParameter.Optional });
        }
    }
}