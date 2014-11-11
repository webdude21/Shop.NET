namespace Shop.Net.Web.Areas.Catalog.Models.Product
{
    using System.Web;

    using Shop.Net.Web.Infrastructure.Filters;

    public class UploadedPictureModel
    {
        [ValidateImageFile]
        public HttpPostedFileBase File { get; set; }
    }
}