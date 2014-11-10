namespace Shop.Net.Web.Areas.Profile
{
    using System.Linq;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using Shop.Net.Data.Contracts;
    using Shop.Net.Web.Controllers;

    public class OrdersController : ProfileBaseController
    {
        public OrdersController(IShopData shopData)
            : base(shopData)
        {
        }

        public ActionResult Index()
        {
            var customerid = this.User.Identity.GetUserId();
            var orders = this.ShopData.Orders.All().Where(o => o.CustomerId == customerid).ToList();

            return View();
        }
    }
}