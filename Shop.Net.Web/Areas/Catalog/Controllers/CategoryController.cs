namespace Shop.Net.Web.Areas.Catalog.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Shop.Net.Data.Contracts;
    using Shop.Net.Resources;
    using Shop.Net.Web.Areas.Catalog.Models.Product;
    using Shop.Net.Web.Controllers;

    public class CategoryController : BaseController
    {
        public CategoryController(IShopData shopData)
            : base(shopData)
        {
        }

        public ActionResult Index(string categoryFriendlyUrl, int page = 0)
        {
            var products =
                 this.ShopData.Products.All()
            .Where(c => c.Category.FriendlyUrl == categoryFriendlyUrl && c.Deleted == false)
            .OrderBy(p => p.Id)
            .Project()
            .To<ProductThumbnailModel>()
            .Skip(GlobalConstants.ProductsPerPage * page)
            .Take(GlobalConstants.ProductsPerPage).ToList();

            return this.View(products);
        }
    }
}