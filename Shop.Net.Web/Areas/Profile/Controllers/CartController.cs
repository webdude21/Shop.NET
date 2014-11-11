namespace Shop.Net.Web.Areas.Profile.Controllers
{
    using Shop.Net.Data.Contracts;
    using Shop.Net.Web.Controllers;

    public class CartController : ProfileBaseController
    {
        public CartController(IShopData shopData)
            : base(shopData)
        {
        }
    }
}