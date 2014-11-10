namespace Shop.Net.Web.Areas.BackOffice.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Microsoft.AspNet.Identity;

    using Shop.Net.Data.Contracts;
    using Shop.Net.Model.Catalog;
    using Shop.Net.Resources;
    using Shop.Net.Web.Areas.BackOffice.Models;
    using Shop.Net.Web.Areas.Catalog.Models.Category;
    using Shop.Net.Web.Controllers;
    using Shop.Net.Web.Infrastructure.Contracts;

    public class CategoriesController : BackOfficeController
    {
        public CategoriesController(IShopData shopData, IImageUploader imageUploader)
            : base(shopData, imageUploader)
        {
        }

        public ActionResult Index(int? page)
        {
            var categoriesCount = this.ShopData.Categories.All().Count();
            var pager = GetPagerViewModel(page, categoriesCount);

            var categories = this.ShopData.Categories
                .All()
                .OrderBy(x => x.Id)
                .Project().To<CategoryViewModel>()
                .Skip(GlobalConstants.ItemsPerPage * pager.CurrentPage)
                .Take(GlobalConstants.ItemsPerPage).ToList();

            var pagerWithCategories = this.GetViewModelWithPager(categories, pager);

            return this.View(pagerWithCategories);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var category = this.ShopData.Categories.All().Where(x => x.Id == id).Project().To<CategoryEditModel>().FirstOrDefault();

            if (category == null)
            {
                return this.HttpNotFound();
            }

            return this.View(category);
        }

        [HttpGet]
        public ActionResult Add()
        {

            return this.View(new CategoryEditModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(CategoryEditModel model)
        {
            var newCategory = new Category
                                  {
                                      Name = model.Name,
                                      FriendlyUrl = model.FriendlyUrl,
                                      MetaTitle = model.MetaTitle,
                                      MetaDescription = model.MetaDescription,
                                      MetaKeyWords = model.MetaKeyWords
                                  };

            if (this.ShopData.Categories.All().Any(c => c.FriendlyUrl == model.FriendlyUrl || c.Name == model.Name))
            {
                this.ModelState.AddModelError(string.Empty, string.Format("Seo Friendly Url & Name must be unique!"));
            }

            if (this.ModelState.IsValid)
            {
                this.ShopData.Categories.Add(newCategory);
                this.ShopData.SaveChanges();
                this.ClearCache();
                return this.RedirectToAction("Index");
            }

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryEditModel model)
        {
            var category = this.ShopData.Categories.Find(model.Id);

            if (this.ShopData.Categories.All().Where(c => c.Id != model.Id).Any(c => c.FriendlyUrl == model.FriendlyUrl || c.Name == model.Name))
            {
                this.ModelState.AddModelError(string.Empty, string.Format("Seo Friendly Url & Name must be unique!"));
            }

            this.TryUpdateModel(category);
            if (this.ModelState.IsValid)
            {
                this.ShopData.SaveChanges();
                this.ClearCache();
                return this.RedirectToAction("Index", "Categories");
            }

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var category = this.ShopData.Categories.All().Where(x => x.Id == id.Value).Project().To<CategoryEditModel>().FirstOrDefault();

            if (category == null)
            {
                return this.HttpNotFound();
            }

            return this.View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var category = this.ShopData.Categories.Find(id);

            this.ShopData.Products.All().ToList().RemoveAll(x => x.Id > 0);
            this.ShopData.Categories.Delete(category);
            this.ShopData.SaveChanges();
            this.ClearCache();
            return this.RedirectToAction("Index");
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                this.ModelState.AddModelError(string.Empty, error);
            }
        }
    }
}