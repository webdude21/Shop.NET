namespace Shop.Net.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Shop.Net.Data.Contracts;
    using Shop.Net.Web.ViewModels.Product;

    public class ProductController : BaseController
    {
        // GET: Product
        public ProductController(IShopData shopData)
            : base(shopData)
        {
        }

        public ActionResult Details(int id)
        {
            var product =
                this.ShopData.Products.All()
                    .Where(x => x.Id == id)
                    .Project().To<ProductDetailsModel>()
                    .FirstOrDefault();

            return this.View(product);
        }

        public ActionResult ByFriendlyUrl(string friendlyUrl)
        {
            var product =
                this.ShopData.Products.All()
                    .Where(x => x.FriendlyUrl == friendlyUrl)
                    .Project().To<ProductDetailsModel>()
                    .FirstOrDefault();

            return this.View("Details", product);
        }
    }
}