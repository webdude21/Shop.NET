namespace Shop.Net.Web.Controllers
{
    using System.Web.Mvc;

    using Shop.Net.Data.Contracts;
    using Shop.Net.Resources;

    [Authorize(Roles = GlobalConstants.AdministratorRole)]
    public abstract class AdministrationController : BaseController
    {
        protected AdministrationController(IShopData shopData)
            : base(shopData)
        {
        }
    }
}