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

    public class OrdersController : CustomerController
    {
        public OrdersController(IShopData shopData)
            : base(shopData)
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public JsonResult GetMyOrders([DataSourceRequest]DataSourceRequest request)
        {
            var userId = this.User.Identity.GetUserId();
            var orders =
                this.ShopData.Orders.All()
                    .Where(o => o.CustomerId == userId)
                    .Project()
                    .To<OrderCustomerViewModel>();

            var result = this.Json(orders.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            result.MaxJsonLength = int.MaxValue;

            return result;
        }

        public ActionResult GetOrderDetails(int orderId, [DataSourceRequest] DataSourceRequest request)
        {
            var userId = this.User.Identity.GetUserId();

            var orderItems = this.ShopData.OrderItems.All()
                  .Where(o => o.OrderId == orderId)
                   .Where(o => o.Order.CustomerId == userId)
                  .Include("Products")
                  .Project()
                  .To<OrderItemViewModel>();

            return this.Json(orderItems.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

    }
}