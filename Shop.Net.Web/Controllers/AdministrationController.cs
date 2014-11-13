namespace Shop.Net.Web.Controllers
{
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using Shop.Net.Data.Contracts;
    using Shop.Net.Model;
    using Shop.Net.Resources;

    [Authorize(Roles = GlobalConstants.AdministratorRole)]
    public abstract class AdministrationController : BaseController
    {
        protected AdministrationController(IShopData shopData, UserManager<ApplicationUser> userManager)
            : base(shopData)
        {
            this.UserManager = userManager;
        }

        public UserManager<ApplicationUser> UserManager { get; set; }
    }
}