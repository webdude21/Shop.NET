namespace Shop.Net.Web.Areas.Catalog.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Shop.Net.Data.Contracts;
    using Shop.Net.Web.Areas.Catalog.Models.Product;
    using Shop.Net.Web.Controllers;

    public class ProductController : BaseController
    {
        public ProductController(IShopData shopData)
            : base(shopData)
        {
        }


        public ActionResult Details(int id)
        {
            var product =
                this.ShopData.Products.All()
                    .Where(x => x.Id == id)
                    .Include(p => p.Images)
                    .Include(p => p.Reviews)
                    .Project().To<ProductDetailsViewModel>()
                    .FirstOrDefault();

            return this.View(product);
        }

        public ActionResult ByFriendlyUrl(string categoryFriendlyUrl, string productFriendlyUrl)
        {
            var product = this.ShopData.Products.All()
                    .Where(c => c.Category.FriendlyUrl == categoryFriendlyUrl)
                    .Where(x => x.FriendlyUrl == productFriendlyUrl)
                    .Project().To<ProductDetailsViewModel>()
                    .FirstOrDefault();

            return this.View("Details", product);
        }
    }
}