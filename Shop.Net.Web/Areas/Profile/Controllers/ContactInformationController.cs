namespace Shop.Net.Web.Areas.Profile.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using Microsoft.AspNet.Identity;

    using Shop.Net.Data.Contracts;
    using Shop.Net.Web.Areas.Profile.Models;
    using Shop.Net.Web.Controllers;

    public class ContactInformationController : ProfileBaseController
    {
        public ContactInformationController(IShopData shopData)
            : base(shopData)
        {

        }

        public ActionResult Index()
        {
            return this.View();
        }
  
        public ActionResult Get([DataSourceRequest] DataSourceRequest request)
        {
            var userId = this.User.Identity.GetUserId();

            var addresses =
                this.ShopData.ContactInformations.All()
                    .Where(x => x.CustomerId == userId)
                    .Project()
                    .To<ContactInformationViewModel>();

            return this.Json(addresses.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        //[AcceptVerbs(HttpVerbs.Post)]
        //public ActionResult Add([DataSourceRequest] DataSourceRequest request, ProductViewModel product)
        //{
        //    if (product != null && ModelState.IsValid)
        //    {
        //        productService.Create(product);
        //    }

        //    return Json(new[] { product }.ToDataSourceResult(request, ModelState));
        //}

        //[AcceptVerbs(HttpVerbs.Post)]
        //public ActionResult Update([DataSourceRequest] DataSourceRequest request, ProductViewModel product)
        //{
        //    if (product != null && ModelState.IsValid)
        //    {
        //        productService.Update(product);
        //    }

        //    return Json(new[] { product }.ToDataSourceResult(request, ModelState));
        //}

        //[AcceptVerbs(HttpVerbs.Post)]
        //public ActionResult Delete([DataSourceRequest] DataSourceRequest request, ProductViewModel product)
        //{
        //    if (product != null)
        //    {
        //        productService.Destroy(product);
        //    }

        //    return Json(new[] { product }.ToDataSourceResult(request, ModelState));
        //}
    }
}