namespace Shop.Net.Web.Areas.BackOffice.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Shop.Net.Data.Contracts;
    using Shop.Net.Model.Catalog;
    using Shop.Net.Resources;
    using Shop.Net.Web.Areas.BackOffice.Models;
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
        public ActionResult Add(CategoryEditModel model)
        {
            var newPorduct = new Product
            {
                Name = model.Name,
                FriendlyUrl = model.FriendlyUrl,
                MetaTitle = model.MetaTitle,
                MetaDescription = model.MetaDescription,
                MetaKeyWords = model.MetaKeyWords,
            };

            if (this.ShopData.Categories.All().Any(c => c.FriendlyUrl == model.FriendlyUrl || c.Name == model.Name))
            {
                this.ModelState.AddModelError(string.Empty, string.Format("Seo Friendly Url & Name must be unique!"));
            }

            if (this.ModelState.IsValid)
            {
                this.ShopData.Categories.Add(newPorduct);
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

            return this.View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryEditModel model)
        {
            var product = this.ShopData.Products.Find(model.Id);

            if (this.ShopData.Products.All().Where(c => c.Id != model.Id).Any(c => c.FriendlyUrl == model.FriendlyUrl || c.Name == model.Name))
            {
                this.ModelState.AddModelError(string.Empty, string.Format("Seo Friendly Url & Name must be unique!"));
            }

            this.TryUpdateModel(product);
            if (this.ModelState.IsValid)
            {
                this.ShopData.SaveChanges();
                this.ClearCache();
                return this.RedirectToAction("Index", "Products");
            }

            return this.View(model);
        }

        public ActionResult Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}