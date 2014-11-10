namespace Shop.Net.Web.Areas.BackOffice.Controllers
{
    using System.Net;
    using System.Web.Mvc;

    using Shop.Net.Data.Contracts;
    using Shop.Net.Web.Controllers;
    using Shop.Net.Web.Infrastructure.Contracts;

    public class ImagesController : BackOfficeController
    {
        public ImagesController(IShopData shopData, IImageUploader imageUploader)
            : base(shopData, imageUploader)
        {
        }


        public ActionResult Delete(int? id)
        {
            if (!Request.IsAjaxRequest())
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                this.HttpNotFound();
            }

            if (id == null)
            {
                return this.HttpNotFound();
            }

            this.DeleteImageById(id);
            this.ShopData.SaveChanges();
            return this.Json(string.Empty, JsonRequestBehavior.AllowGet);
        }
    }
}