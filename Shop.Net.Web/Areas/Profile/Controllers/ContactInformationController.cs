namespace Shop.Net.Web.Areas.Profile.Controllers
{
    using Shop.Net.Data.Contracts;
    using Shop.Net.Web.Controllers;

    public class ContactInformationController : ProfileBaseController
    {
        public ContactInformationController(IShopData shopData)
            : base(shopData)
        {

        }
    }
}