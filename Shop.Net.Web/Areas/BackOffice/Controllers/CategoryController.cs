namespace Shop.Net.Web.Areas.BackOffice.Controllers
{
    using System.Web.Mvc;

    public class CategoryController : Controller
    {
        // GET: BackOffice/Category
        public ActionResult Index()
        {
            return this.View();
        }
    }
}