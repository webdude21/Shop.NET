namespace Shop.Net.Web
{
    using System.Web.Mvc;
    using System.Web.Routing;

    using Shop.Net.Resources;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "ImageDownload",
                url: GlobalConstants.ProductImagesRelativePath.Substring(1) + "{fileName}",
                defaults: new { controller = "ImageDownload", action = "GetImage" },
                constraints: new { fileName = @"\S+" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Pages", action = "Index", id = UrlParameter.Optional });
        }
    }
}