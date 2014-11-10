namespace Shop.Net.Web.Areas.BackOffice
{
    using System.Web.Mvc;

    public class BackOfficeAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "BackOffice";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "BackOffice_default", 
                "BackOffice/{controller}/{action}/{id}", 
                new { controller = "Products", action = "Index", id = UrlParameter.Optional });
        }
    }
}