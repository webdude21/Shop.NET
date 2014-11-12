namespace Shop.Net.Web.Controllers
{
    using System.Web.Mvc;

    using Shop.Net.Data.Contracts;
    using Shop.Net.Resources;

    [Authorize(Roles = GlobalConstants.AdministratorRole + "," + GlobalConstants.EmployeeRole + "," + GlobalConstants.CustomerRole)]
    public class CustomerController : BaseController
    {
        public CustomerController(IShopData shopData)
            : base(shopData)
        {
        }
    }
}