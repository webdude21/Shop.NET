namespace Shop.Net.Web.Controllers
{
    using System.Web.Mvc;

    using Shop.Net.Data.Contracts;
    using Shop.Net.Resources;
    using Shop.Net.Web.Models;

    public class BaseController : Controller
    {
        public BaseController(IShopData shopData)
        {
            this.ShopData = shopData;
        }

        protected IShopData ShopData { get; set; }

        protected static int GetCurrentPage(int? page)
        {
            var currentPage = page.GetValueOrDefault(1);

            if (currentPage < 1)
            {
                currentPage = 1;
            }
            return currentPage - 1;
        }

        protected static int GetTotalPages(int itemsCount)
        {
            return itemsCount / GlobalConstants.ItemsPerPage;
        }

        protected PagerViewModel GetPagerViewModel(int? page, int itemsCount)
        {
            return new PagerViewModel { CurrentPage = GetCurrentPage(page), TotalPages = GetTotalPages(itemsCount) };
        }

        protected ViewModelWithPager<T> GetViewModelWithPager<T>(T viewmodel, PagerViewModel pager)
        {
            return new ViewModelWithPager<T>(viewmodel, pager);
        }

        protected void ClearCache()
        {
            foreach (System.Collections.DictionaryEntry entry in HttpContext.Cache)
            {
                HttpContext.Cache.Remove((string)entry.Key);
            }
        }
    }
}