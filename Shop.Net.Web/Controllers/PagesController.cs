namespace Shop.Net.Web.Controllers
{
    using System.Web.Mvc;

    using Shop.Net.Data.Contracts;

    [RequireHttps]
    public class PagesController : BaseController
    {
        public PagesController(IShopData shopData)
            : base(shopData)
        {
        }

        public ActionResult Index()
        {
            return this.RedirectToRoutePermanent("CatalogIndex");
        }

        public ActionResult About()
        {
            this.ViewBag.Message = "Your application description page.";

            return this.View();
        }

        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";

            return this.View();
        }
    }
}