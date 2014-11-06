using System.Web.Mvc;

namespace Shop.Net.Web.Areas.Catalog
{
    public class CatalogAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Catalog";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {

            context.MapRoute(
                name: "Catalog",
                url: "Catalog/{categoryFriendlyUrl}/{productFriendlyUrl}",
                defaults:
                    new
                        {
                            controller = "Product",
                            action = "ByFriendlyUrl",
                            parameters = new { categoryFriendlyUrl = string.Empty, productFriendlyUrl = string.Empty }
                        });

            context.MapRoute(
                "Catalog_default",
                "Catalog/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional });
        }
    }
}