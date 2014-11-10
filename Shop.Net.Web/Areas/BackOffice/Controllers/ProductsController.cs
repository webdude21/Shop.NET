namespace Shop.Net.Web.Areas.BackOffice.Controllers
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using System.Web.UI.WebControls;

    using AutoMapper.QueryableExtensions;

    using Shop.Net.Data.Contracts;
    using Shop.Net.Model.Catalog;
    using Shop.Net.Resources;
    using Shop.Net.Web.Areas.BackOffice.Models;
    using Shop.Net.Web.Controllers;
    using Shop.Net.Web.Infrastructure.Contracts;

    using WebGrease.Css.Extensions;

    public class ProductsController : BackOfficeController
    {
        public ProductsController(IShopData shopData, IImageUploader imageUploader)
            : base(shopData, imageUploader)
        {
        }

        public ActionResult Index(int? page)
        {
            var productsCount = this.ShopData.Products.All().Count();
            var pager = GetPagerViewModel(page, productsCount);

            var products = this.ShopData.Products
                .All()
                .OrderBy(x => x.Id)
                .Project().To<ProductsListModel>()
                .Skip(GlobalConstants.ItemsPerPage * pager.CurrentPage)
                .Take(GlobalConstants.ItemsPerPage).ToList();

            var pagerWithProducts = this.GetViewModelWithPager(products, pager);

            return this.View(pagerWithProducts);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var newProduct = new ProductEditModel();
            this.PutCategoriesInTheViewDictionary(newProduct);
            return this.View(newProduct);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ProductEditModel model)
        {
            var category = this.ShopData.Categories.Find(model.Category.Id);

            if (category == null)
            {
                this.ModelState.AddModelError(string.Empty, string.Format("You must add a valid category!"));
                return this.View(model);
            }

            var newPorduct = ConvertEditModelToModel(model, category);
            this.CheckForDuplicateFriendlyUrlAndName(model);

            if (this.ModelState.IsValid)
            {
                var savedProduct = this.ShopData.Products.Add(newPorduct);
                this.ShopData.SaveChanges();
                ImageUploader.UploadImages(this.Request, this.Server, savedProduct.Images);
                this.ShopData.SaveChanges();
                this.ClearCache();
                return this.RedirectToAction("Index");
            }

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = this.ShopData.Products
                .All()
                .Where(x => x.Id == id)
                .Include(p => p.Images)
                .Project().To<ProductEditModel>().FirstOrDefault();

            if (product == null)
            {
                return this.HttpNotFound();
            }

            this.PutCategoriesInTheViewDictionary(product);

            return this.View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductEditModel model)
        {
            var product = this.ShopData.Products.Find(model.Id);

            this.CheckForDuplicateFriendlyUrlAndName(model);
               
            var category = this.ShopData.Categories.Find(model.Category.Id);

            if (category != null)
            {
                product.Category = category;
            }

            this.TryUpdateModel(product);
            if (this.ModelState.IsValid)
            {
                ImageUploader.UploadImages(this.Request, this.Server, product.Images);
                this.ShopData.SaveChanges();
                this.ClearCache();
                return this.RedirectToAction("Index", "Products");
            }

            this.PutCategoriesInTheViewDictionary(model);

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = this.ShopData.Products.All()
                .Where(x => x.Id == id.Value)
                .Include(p => p.Images)
                .Project().To<ProductEditModel>().FirstOrDefault();

            if (product == null)
            {
                return this.HttpNotFound();
            }

            return this.View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var product = this.ShopData.Products.Find(id);
            this.DeleteProductDependencies(id);
            this.ShopData.Products.Delete(product);
            this.ShopData.SaveChanges();
            this.ClearCache();
            return this.RedirectToAction("Index");
        }


        private static Product ConvertEditModelToModel(ProductEditModel model, Category category)
        {
            return new Product
            {
                Name = model.Name,
                FriendlyUrl = model.FriendlyUrl,
                MetaTitle = model.MetaTitle,
                MetaDescription = model.MetaDescription,
                MetaKeyWords = model.MetaKeyWords,
                Category = category,
                Price = model.Price,
                Manufacturer = model.Manufacturer,
                ManufacturerPartNumber = model.ManufacturerPartNumber,
                AllowCustomerComments = model.AllowCustomerComments,
                AllowCustomerReviews = model.AllowCustomerReviews,
                AllowCustomerRating = model.AllowCustomerRating,
                CreatedOnUtc = DateTime.UtcNow,
                UpdatedOnUtc = DateTime.UtcNow,
                Description = model.Description,
                Height = model.Height,
                Published = model.Published,
                Length = model.Length,
                ProductCost = model.ProductCost,
                Quantity = model.Quantity,
                Sku = model.Sku,
                Weight = model.Weight,
                Width = model.Width,
            };
        }

        private void PutCategoriesInTheViewDictionary(ProductEditModel product)
        {
            this.ViewData["Categories"] = this.ShopData.Categories.All().Project().To<CategorySimpleViewModel>().ToList();
            this.ViewData["SelectedCategory"] = product.Category == null ? (object)null : product.Category.Id;
        }

        private void CheckForDuplicateFriendlyUrlAndName(ProductEditModel model)
        {
            if (this.ShopData.Products.All().Any(c => c.FriendlyUrl == model.FriendlyUrl || c.Name == model.Name))
            {
                this.ModelState.AddModelError(string.Empty, string.Format("Seo Friendly Url & Name must be unique!"));
            }
        }
    }
}