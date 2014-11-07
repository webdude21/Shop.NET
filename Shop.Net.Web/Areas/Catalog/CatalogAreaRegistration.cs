namespace Shop.Net.Web.Areas.Catalog
{
    using System.Web.Mvc;

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
                "Catalog", 
                "Catalog/{categoryFriendlyUrl}/{productFriendlyUrl}", 
                new { controller = "Product", action = "ByFriendlyUrl" }, 
                new { categoryFriendlyUrl = @"\S+", productFriendlyUrl = @"\S+" });

            context.MapRoute(
                "Catalog_Categories", 
                "Catalog/{categoryFriendlyUrl}", 
                new { controller = "Category", action = "Index" }, 
                new { categoryFriendlyUrl = @"\S+" });

            context.MapRoute(
                "Catalog_default", 
                "Catalog/{controller}/{action}/{id}", 
                new { action = "Index", id = UrlParameter.Optional });
        }
    }
}