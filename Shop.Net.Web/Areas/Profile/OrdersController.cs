namespace Shop.Net.Web.Areas.Profile
{
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Microsoft.AspNet.Identity;

    using Shop.Net.Data.Contracts;
    using Shop.Net.Web.Areas.Profile.Models;
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
            var orders = this.ShopData.Orders.All()
                .Where(o => o.CustomerId == customerid)
                .Include(o => o.Products)
                .Project().To<OrderCustomerViewModel>().ToList();

            return View(orders);
        }
    }
}