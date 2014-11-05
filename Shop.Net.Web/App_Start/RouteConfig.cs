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
                url: "catalog/{categoryFriendlyUrl}/{productFriendlyUrl}",
                defaults: new { controller = "Product", action = "ByFriendlyUrl", categoryFriendlyUrl = string.Empty, productFriendlyUrl = string.Empty, });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Pages", action = "Index", id = UrlParameter.Optional });
        }
    }
}