namespace Shop.Net.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Shop.Net.Data.Contracts;
    using Shop.Net.Resources;
    using Shop.Net.Web.Models.Rating;

    public class ReviewsController : BaseController
    {
        public ReviewsController(IShopData shopData)
            : base(shopData)
        {
        }

        [HttpGet]
        public ActionResult GetReviews(int? page, int? productId)
        {
            var results = this.ShopData.Reviews.All()
                .Where(x => x.ProductId == productId)
                .OrderBy(x => x.Id)
                .Project().To<ReviewViewModel>()
                .Skip(GlobalConstants.ItemsPerPage * page.GetValueOrDefault(0))
                .Take(GlobalConstants.ItemsPerPage).ToList();

            return this.PartialView("_ReviewsPartial", results);
        }
    }
}