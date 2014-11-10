namespace Shop.Net.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Shop.Net.Data.Contracts;
    using Shop.Net.Resources;
    using Shop.Net.Web.Infrastructure.Contracts;

    [Authorize(Roles = GlobalConstants.AdministratorRole + "," + GlobalConstants.EmployeeRole)]
    public class BackOfficeController : BaseController
    {
        public BackOfficeController(IShopData shopData, IImageUploader imageUploader)
            : base(shopData)
        {
            this.ImageUploader = imageUploader;
        }

        public IImageUploader ImageUploader { get; set; }

        [NonAction]
        protected void DeleteImagesByProductId(int id)
        {
            var imagesToDelete = this.ShopData.Images.All().Where(p => p.ProductId == id).ToList();

            this.ImageUploader.DeleteImagesFromFileSystem(imagesToDelete, this.Server);

            foreach (var image in imagesToDelete)
            {
                this.ShopData.Images.Delete(image);
            }
        }

        [NonAction]
        protected void DeleteReviewsByProductId(int id)
        {
            var reviewsToDelete = this.ShopData.Reviews.All().Where(p => p.ProductId == id).ToList();
            foreach (var review in reviewsToDelete)
            {
                this.ShopData.Reviews.Delete(review);
            }
        }

        [NonAction]
        protected void DeleteProductDependencies(int id)
        {
            this.DeleteImagesByProductId(id);
            this.DeleteReviewsByProductId(id);
        }

        [NonAction]
        protected void DeleteCategoryDependencies(int id)
        {
            var productToDelete = this.ShopData.Products.All().Where(c => c.Category.Id == id).ToList();

            foreach (var product in productToDelete)
            {
                this.DeleteImagesByProductId(product.Id);
                this.DeleteReviewsByProductId(product.Id);
            }
        }
    }
}