namespace Shop.Net.Web.Controllers
{
    using System.Web.Mvc;

    using Shop.Net.Data.Contracts;
    using Shop.Net.Resources;
    using Shop.Net.Web.Infrastructure.Contracts;

    [Authorize(Roles = GlobalConstants.AdministratorRole)]
    public abstract class AdministrationController : BaseController
    {
        protected AdministrationController(IShopData shopData, IRoleManager roleManager)
            : base(shopData)
        {
            this.RoleManager = roleManager;
        }

        public IRoleManager RoleManager { get; set; }
    }
}