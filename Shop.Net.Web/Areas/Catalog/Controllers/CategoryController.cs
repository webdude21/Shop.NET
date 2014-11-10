namespace Shop.Net.Web.Areas.Catalog.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Shop.Net.Data.Contracts;
    using Shop.Net.Resources;
    using Shop.Net.Web.Areas.Catalog.Models.Category;
    using Shop.Net.Web.Areas.Catalog.Models.Product;
    using Shop.Net.Web.Controllers;

    public class CategoryController : BaseController
    {
        public CategoryController(IShopData shopData)
            : base(shopData)
        {
        }

        public ActionResult Index(string categoryFriendlyUrl, int? page = 0)
        {
            var products =
                this.ShopData.Products.All()
                    .Where(c => c.Category.FriendlyUrl == categoryFriendlyUrl && c.Published)
                    .OrderBy(p => p.Id)
                    .Include(p => p.Images)
                    .Project()
                    .To<ProductThumbnailModel>()
                    .Skip(GlobalConstants.ItemsPerPage * page.GetValueOrDefault(0))
                    .Take(GlobalConstants.ItemsPerPage)
                    .ToList();

            if (products.Count == 0)
            {
                var category = this.ShopData.Categories.All()
                        .Where(c => c.FriendlyUrl == categoryFriendlyUrl)
                        .Project()
                        .To<CategoryViewModel>()
                        .First();
                return this.View("EmptyCategory", category);
            }

            return this.View(products);
        }
    }
}