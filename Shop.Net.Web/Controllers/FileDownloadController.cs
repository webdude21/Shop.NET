namespace Shop.Net.Web.Controllers 
{
    using System.Linq;
    using System.Web.Mvc;

    using Shop.Net.Data.Contracts;

    public class FileDownloadController : BaseController
    {
        public FileDownloadController(IShopData shopData)
            : base(shopData)
        {
        }

        public FilePathResult GetImage(string fileName)
        {
            var image = this.ShopData.Images.All().FirstOrDefault(f => f.Url.Contains(fileName));
            return this.File(Server.MapPath("~" + image.Url), image.MimeType, image.FileName);
        }
    }
}