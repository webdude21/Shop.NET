namespace Shop.Net.Web.Areas.Catalog.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web.Mvc;

    using Antlr.Runtime.Misc;

    using AutoMapper.QueryableExtensions;

    using Microsoft.Ajax.Utilities;

    using Shop.Net.Data.Contracts;
    using Shop.Net.Model.Catalog;
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

        public ActionResult Index(string categoryFriendlyUrl, int? page, string orderby, bool? asc)
        {
            var matchingProducts =
                this.ShopData.Products.All()
                    .Where(c => c.Category.FriendlyUrl == categoryFriendlyUrl && c.Published)
                    .Project()
                    .To<ProductThumbnailModel>();

            var pager = this.GetPagerViewModel(page, matchingProducts.Count());

            var orderedCollection = this.Sort(orderby, asc, matchingProducts);

            var products = orderedCollection
                    .Skip(GlobalConstants.ItemsPerPage * pager.CurrentPage)
                    .Take(GlobalConstants.ItemsPerPage)
                    .ToList();

            var pagerWithProducts = this.GetViewModelWithPager(products, pager);

            if (products.Count == 0)
            {
                var category = this.ShopData.Categories.All()
                        .Where(c => c.FriendlyUrl == categoryFriendlyUrl)
                        .Project()
                        .To<CategoryViewModel>()
                        .First();
                return this.View("EmptyCategory", category);
            }

            return this.View(pagerWithProducts);
        }

        private IOrderedQueryable<ProductThumbnailModel> Sort(string orderby, bool? asc, IQueryable<ProductThumbnailModel> orderable)
        {
            var ascending = asc.GetValueOrDefault(true);

            if (orderby.IsNullOrWhiteSpace())
            {
                orderby = "name";
            }

            switch (orderby.ToLowerInvariant())
            {
                case "price":
                    return ascending ? orderable.OrderBy(x => x.Price) : orderable.OrderByDescending(x => x.Price);
                default:
                    return ascending ? orderable.OrderBy(x => x.Name) : orderable.OrderByDescending(x => x.Name);
            }
        }
    }
}