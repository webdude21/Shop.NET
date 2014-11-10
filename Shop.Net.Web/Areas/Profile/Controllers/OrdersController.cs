namespace Shop.Net.Web.Areas.Profile.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

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
            return this.View();
        }

        public JsonResult GetOrders([DataSourceRequest]DataSourceRequest request)
        {
            var userId = this.User.Identity.GetUserId();
            var orders =
                this.ShopData.Orders.All()
                    .Where(o => o.CustomerId == userId)
                    .Include(o => o.OrderItems)
                    .Include("Products")
                    .Project()
                    .To<OrderCustomerViewModel>();

            return this.Json(orders.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
}