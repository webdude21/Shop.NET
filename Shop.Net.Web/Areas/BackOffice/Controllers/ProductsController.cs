namespace Shop.Net.Web.Areas.BackOffice.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Shop.Net.Data.Contracts;
    using Shop.Net.Model.Catalog;
    using Shop.Net.Resources;
    using Shop.Net.Web.Areas.BackOffice.Models;
    using Shop.Net.Web.Areas.Catalog.Models.Category;
    using Shop.Net.Web.Controllers;

    public class ProductsController : BackOfficeController
    {
        // GET: BackOffice/Product
        public ProductsController(IShopData shopData)
            : base(shopData)
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
                .Take(GlobalConstants.ItemsPerPage);

            var pagerWithProducts = this.GetViewModelWithPager(products, pager);

            return this.View(pagerWithProducts);
        }

        [HttpGet]
        public ActionResult Add()
        {

            return this.View(new ProductEditModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ProductEditModel model)
        {
            //var newPorduct = new Product
            //{
            //    Name = model.Name,
            //    FriendlyUrl = model.FriendlyUrl,
            //    MetaTitle = model.MetaTitle,
            //    MetaDescription = model.MetaDescription,
            //    MetaKeyWords = model.MetaKeyWords,
            //    Category = model.Category,
            //    Price = model.Price,
            //    Manufacturer = model.Manufacturer,
            //    ManufacturerPartNumber = model.ManufacturerPartNumber,
            //    AllowCustomerComments = model.AllowCustomerComments,
            //    AllowCustomerReviews = model.AllowCustomerReviews,
            //    AllowCustomerRating = model.AllowCustomerRating,
            //    CreatedOnUtc = DateTime.UtcNow,
            //    Description = model.Description,
            //    Height = model.Height
            //};

            var newPorduct = Mapper.Map<Product>(model);

            if (this.ShopData.Products.All().Any(c => c.FriendlyUrl == model.FriendlyUrl || c.Name == model.Name))
            {
                this.ModelState.AddModelError(string.Empty, string.Format("Seo Friendly Url & Name must be unique!"));
            }

            if (this.ModelState.IsValid)
            {
                this.ShopData.Products.Add(newPorduct);
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

            var product = this.ShopData.Products.All().Where(x => x.Id == id).Project().To<ProductEditModel>().FirstOrDefault();

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

            if (this.ShopData.Products.All().Where(c => c.Id != model.Id).Any(c => c.FriendlyUrl == model.FriendlyUrl || c.Name == model.Name))
            {
                this.ModelState.AddModelError(string.Empty, string.Format("Seo Friendly Url & Name must be unique!"));
            }

            var category = this.ShopData.Categories.Find(model.Category.Id);

            if (category != null)
            {
                product.Category = category;
            }

            this.TryUpdateModel(product);
            if (this.ModelState.IsValid)
            {
                this.ShopData.SaveChanges();
                this.ClearCache();
                return this.RedirectToAction("Index", "Products");
            }

            this.PutCategoriesInTheViewDictionary(model);

            return this.View(model);
        }

        public ActionResult Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        private void PutCategoriesInTheViewDictionary(ProductEditModel product)
        {

            this.ViewData["Categories"] =
                this.ShopData.Categories.All().Project().To<CategorySimpleViewModel>().ToList();
            this.ViewData["SelectedCategory"] = product.Category.Id;
        }
    }
}