namespace Shop.Net.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Caching;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Shop.Net.Data.Contracts;
    using Shop.Net.Web.Areas.Catalog.Models.Category;

    public class CategoryMenuController : BaseController
    {
        public CategoryMenuController(IShopData shopData)
            : base(shopData)
        {
        }

        [ChildActionOnly]
        public ActionResult RenderCategoriesMenu()
        {
            const string CategoryNames = "CategoryNames";

            if (this.HttpContext.Cache[CategoryNames] == null)
            {
                var listOfCategories = this.ShopData.Categories.All().OrderBy(c => c.Name).Project().To<CategoryViewModel>().ToList();
                this.HttpContext.Cache.Add(CategoryNames, listOfCategories, null, DateTime.Now.AddHours(1), TimeSpan.Zero, CacheItemPriority.Default, null);
            }

            var cachedCategories = this.HttpContext.Cache[CategoryNames];

            return this.PartialView("_CategoriesMenuPartial", cachedCategories);
        }
    }
}