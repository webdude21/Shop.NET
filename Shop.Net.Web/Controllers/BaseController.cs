namespace Shop.Net.Web.Controllers
{
    using System.Web.Mvc;

    using Shop.Net.Data;
    using Shop.Net.Data.Contracts;

    public class BaseController : Controller
    {
        public BaseController(IShopData shopData)
        {
            this.ShopData = shopData;
        }

        public BaseController()
            : this(new ShopData(new ShopDbContext()))
        {
        }

        protected IShopData ShopData { get; set; }
    }
}