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
    }
}