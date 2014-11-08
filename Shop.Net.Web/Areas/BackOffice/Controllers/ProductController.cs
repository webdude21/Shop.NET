namespace Shop.Net.Web.Areas.BackOffice.Controllers
{
    using Shop.Net.Data.Contracts;
    using Shop.Net.Web.Controllers;

    public class ProductController : BackOfficeController
    {
        // GET: BackOffice/Product
        public ProductController(IShopData shopData)
            : base(shopData)
        {
        }

        //public ActionResult Index()
        //{
        //    //this.ShopData.Products.All().OrderBy(x => x.Id).Project()

        //    //return this.View();
        //}
    }
}