namespace Shop.Net.Web.Controllers
{
    using System.Web.Mvc;

    using Shop.Net.Data.Contracts;

    public class BaseController : Controller
    {
        public BaseController(IShopData shopData)
        {
            this.ShopData = shopData;
        }

        protected IShopData ShopData { get; set; }

        protected void ClearCache()
        {
            foreach (System.Collections.DictionaryEntry entry in HttpContext.Cache)
            {
                HttpContext.Cache.Remove((string)entry.Key);
            }
        }
    }
}