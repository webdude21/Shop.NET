namespace Shop.Net.Web.Areas.Catalog.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Caching;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Shop.Net.Data.Contracts;
    using Shop.Net.Resources;
    using Shop.Net.Web.Areas.Catalog.Models.Product;
    using Shop.Net.Web.Controllers;

    public class ProductController : BaseController
    {
        // GET: Product
        public ProductController(IShopData shopData)
            : base(shopData)
        {
        }

        public ActionResult Index()
        {
            const string HomePageProducts = "HomePageProducts";

            if (this.HttpContext.Cache[HomePageProducts] == null)
            {
                var listOfProducts =
                                this.ShopData.Products.All()
                                .OrderByDescending(product => product.CreatedOnUtc)
                                .Project()
                                .To<ProductThumbnailModel>()
                                .Take(GlobalConstants.ProductsOnHomePage)
                                .ToList();

                this.HttpContext.Cache.Add(HomePageProducts, listOfProducts, null, DateTime.Now.AddHours(1), TimeSpan.Zero, CacheItemPriority.Default, null);
            }

            var cachedProducts = this.HttpContext.Cache[HomePageProducts];
            return this.View(cachedProducts);
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

        public ActionResult ByFriendlyUrl(string categoryFriendlyUrl, string productFriendlyUrl)
        {
            if (string.IsNullOrWhiteSpace(categoryFriendlyUrl) && string.IsNullOrWhiteSpace(productFriendlyUrl))
            {
                return this.RedirectToAction("Index");
            }

            var product =
                this.ShopData.Products.All()
                    .Where(c => c.Category.FriendlyUrl == categoryFriendlyUrl)
                    .Where(x => x.FriendlyUrl == productFriendlyUrl)
                    .Project().To<ProductDetailsModel>()
                    .FirstOrDefault();

            return this.View("Details", product);
        }
    }
}