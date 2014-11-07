namespace Shop.Net.Web.Controllers
{
    using System.Web.Mvc;

    using Shop.Net.Data.Contracts;
    using Shop.Net.Resources;

    [Authorize(Roles = GlobalConstants.AdministratorRole + "," + GlobalConstants.EmployeeRole)]
    public class BackOfficeController : BaseController
    {
        public BackOfficeController(IShopData shopData)
            : base(shopData)
        {
        }
    }
}