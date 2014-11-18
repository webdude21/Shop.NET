namespace Shop.Net.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Microsoft.AspNet.Identity;

    using Shop.Net.Data.Contracts;
    using Shop.Net.Model.Marketing;
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

        [HttpGet]
        public ActionResult LeaveReview(int? productId)
        {
            var currentUserId = this.User.Identity.GetUserId();
            var userHasBoughtThisItem = this.ShopData.Orders.All()
                .Where(x => x.CustomerId == currentUserId)
                .Any(p => p.OrderItems
                    .Any(x => x.OrderedProductId == productId));

            var isReviewdByThisUser =
                    this.ShopData.Reviews.All().Any(x => x.AuthorId == currentUserId && x.ProductId == productId);

            if (isReviewdByThisUser)
            {
                return this.PartialView("_AlreadyReviewdPartial");
            }

            if (userHasBoughtThisItem)
            {
                return this.PartialView("_PostReviewPartial", new ReviewOutputModel { ProductId = productId.GetValueOrDefault(0) });
            }

            return this.PartialView("_ErrorPostingReview");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LeaveReview(ReviewOutputModel newReview)
        {
            var currentUserId = this.User.Identity.GetUserId();
            var product = this.ShopData.Products.Find(newReview.ProductId);

            if (this.ModelState.IsValid)
            {
                var isReviewdByThisUser =
                this.ShopData.Reviews.All().Any(x => x.AuthorId == currentUserId && x.ProductId == newReview.ProductId);

                if (isReviewdByThisUser)
                {
                    return this.PartialView("_AlreadyReviewdPartial");
                }

                AddNewProduct(newReview, currentUserId, product);
                this.ShopData.SaveChanges();
                return this.PartialView("_SuccesfullReview");
            }

            return this.PartialView("_PostReviewPartial", newReview);
        }

        private static void AddNewProduct(ReviewOutputModel newReview, string currentUserId, Model.Catalog.Product product)
        {
            product.Reviews.Add(new Review
            {
                AuthorId = currentUserId,
                CustomerServiceRating = newReview.CustomerServiceRating,
                PriceRating = newReview.PriceRating,
                QualityRating = newReview.QualityRating,
                ShipingRating = newReview.ShipingRating,
                Content = newReview.Content,
                ProductId = newReview.ProductId
            });
        }
    }
}