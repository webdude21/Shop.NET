namespace Shop.Net.Web.Areas.BackOffice.Controllers
{
    using System.Data.Entity;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using Shop.Net.Data.Contracts;
    using Shop.Net.Web.Areas.BackOffice.Models;
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
            var orders =
                this.ShopData.Orders.All()
                    .Include(o => o.OrderItems)
                    .Include("AspNetUsers")
                    .Include("Products")
                    .Project()
                    .To<OrderEmployeeViewModel>();

            return this.Json(orders.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return this.View();
        }
    }
}