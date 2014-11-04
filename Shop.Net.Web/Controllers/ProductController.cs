namespace Shop.Net.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Shop.Net.Web.ViewModels.Product;

    public class ProductController : BaseController
    {
        // GET: Product
        public ActionResult Details(int id)
        {
            var viewLaptop =
                this.ShopData.Products.All()
                    .Where(x => x.Id == id)
                    .Project().To<ProductDetailsModel>()
                    .FirstOrDefault();

            return this.View(viewLaptop);
        }
    }
}