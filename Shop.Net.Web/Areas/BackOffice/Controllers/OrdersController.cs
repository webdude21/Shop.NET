namespace Shop.Net.Web.Areas.BackOffice.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using Shop.Net.Data;
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
                    .Project()
                    .To<OrderEmployeeViewModel>();

            return this.Json(orders.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetOrderDetails(int orderId, [DataSourceRequest] DataSourceRequest request)
        {
            var orderItems = this.ShopData.OrderItems.All()
                  .Where(o => o.OrderId == orderId)
                  .Include("Products")
                  .Project()
                  .To<OrderItemEmployeeViewModel>();

            return this.Json(orderItems.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteOrder([DataSourceRequest] DataSourceRequest request, OrderEmployeeViewModel product)
        {
            var dataProduct = this.ShopData.Orders.Find(product.Id);

                if (dataProduct != null)
                {
                    this.ShopData.Orders.Delete(dataProduct);
                    this.ShopData.SaveChanges();
                }

            return this.Json(new[] { product }.ToDataSourceResult(request, this.ModelState));
        }

        public ActionResult Index()
        {
            return this.View();
        }
    }
}