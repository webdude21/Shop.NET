namespace Shop.Net.Web.Areas.BackOffice.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Microsoft.AspNet.Identity;

    using Shop.Net.Data.Contracts;
    using Shop.Net.Model.Catalog;
    using Shop.Net.Web.Areas.BackOffice.Models;
    using Shop.Net.Web.Areas.Catalog.Models.Category;
    using Shop.Net.Web.Controllers;

    public class CategoryController : BackOfficeController
    {
        // GET: BackOffice/Category
        public CategoryController(IShopData shopData)
            : base(shopData)
        {
        }

        public ActionResult Index()
        {
            var categories = this.ShopData.Categories.All().OrderBy(x => x.Name).Project().To<CategoryViewModel>();

            return this.View(categories);
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

            this.TryValidateModel(model);
            if (this.ModelState.IsValid)
            {
                this.ShopData.Categories.Add(newCategory);
                this.ShopData.SaveChanges();
                return this.RedirectToAction("Index");
            }

            return this.RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryEditModel model)
        {
            var category = this.ShopData.Categories.Find(model.Id);

            this.TryUpdateModel(category);
            if (this.ModelState.IsValid)
            {
                this.ShopData.SaveChanges();
                this.ClearCache();
                return this.RedirectToAction("Index", "Category");
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