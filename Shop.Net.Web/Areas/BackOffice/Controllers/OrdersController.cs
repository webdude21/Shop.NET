namespace Shop.Net.Web.Areas.BackOffice.Controllers
{
    using System.Data.Entity;
    using System.Linq;
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

        public JsonResult Get([DataSourceRequest] DataSourceRequest request)
        {
            var orders = this.ShopData.Orders.All().Project().To<OrderEmployeeViewModel>();

            return this.Json(orders.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDetails(int orderId, [DataSourceRequest] DataSourceRequest request)
        {
            var orderItems =
                this.ShopData.OrderItems.All()
                    .Where(o => o.OrderId == orderId)
                    .Include("Products")
                    .Project()
                    .To<OrderItemEmployeeViewModel>();

            return this.Json(orderItems.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, OrderEmployeeViewModel order)
        {
            this.ShopData.Orders.Find(order.Id);
            this.TryUpdateModel(order);

            if (this.ModelState.IsValid)
            {
                this.ShopData.SaveChanges();
            }

            return this.Json(new[] { order }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, OrderEmployeeViewModel modelOrder)
        {
            var order = this.ShopData.Orders.All().FirstOrDefault(x => x.Id == modelOrder.Id);

            if (order != null)
            {
                this.ShopData.Orders.Delete(order);
                this.ShopData.SaveChanges();
            }

            return this.Json(new[] { modelOrder }.ToDataSourceResult(request, this.ModelState));
        }

        public ActionResult Index()
        {
            return this.View();
        }
    }
}