namespace Shop.Net.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Caching;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Shop.Net.Data.Contracts;
    using Shop.Net.Resources;
    using Shop.Net.Web.Areas.Catalog.Models.Category;
    using Shop.Net.Web.Areas.Catalog.Models.Product;

    [RequireHttps]
    public class PagesController : BaseController
    {
        public PagesController(IShopData shopData)
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

        public ActionResult About()
        {
            this.ViewBag.Message = "Your application description page.";

            return this.View();
        }

        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";

            return this.View();
        }

    }
}