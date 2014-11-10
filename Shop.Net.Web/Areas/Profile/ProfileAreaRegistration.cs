namespace Shop.Net.Web.Areas.Profile
{
    using System.Web.Mvc;

    public class ProfileAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Profile";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Profile_default", 
                "Profile/{controller}/{action}/{id}", 
                new { action = "Index", id = UrlParameter.Optional });
        }
    }
}