namespace Shop.Net.Web.Areas.BackOffice.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using Microsoft.AspNet.Identity;

    using Shop.Net.Data.Contracts;
    using Shop.Net.Web.Areas.Profile.Models;
    using Shop.Net.Web.Controllers;
    using Shop.Net.Web.Infrastructure.Contracts;

    public class OrdersController : BackOfficeController
    {
        public OrdersController(IShopData shopData, IImageUploader imageUploader)
            : base(shopData, imageUploader)
        {
        }

        public JsonResult GetOrders([DataSourceRequest]DataSourceRequest request)
        {
            var orders = this.ShopData.Orders.All()
                    .Include(o => o.Customer)
                    .Include(o => o.OrderItems)
                    .Include("Products")
                    .Project()
                    .To<OrderCustomerViewModel>();

            return this.Json(orders.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
}