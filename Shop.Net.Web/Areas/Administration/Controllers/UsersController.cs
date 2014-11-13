namespace Shop.Net.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using Shop.Net.Data.Contracts;
    using Shop.Net.Web.Areas.Administration.Models;
    using Shop.Net.Web.Areas.Profile.Models;
    using Shop.Net.Web.Controllers;
    using Shop.Net.Web.Infrastructure.Contracts;

    public class UsersController : AdministrationController
    {
        public UsersController(IShopData shopData, IRoleManager roleManager)
            : base(shopData, roleManager)
        {
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, UserViewModel userModel)
        {
            this.RoleManager.UpdateRoles(userModel);
            return this.Json(new[] { userModel }.ToDataSourceResult(request, this.ModelState));
        }

        public ActionResult Get([DataSourceRequest] DataSourceRequest request)
        {
            var users = this.ShopData.Users.All().Project().To<UserViewModel>().ToList().AsQueryable();

            foreach (var userViewModel in users)
            {
                this.RoleManager.FillRoles(userViewModel);
            }

            return this.Json(users.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, UserViewModel userModel)
        {
            var user = this.ShopData.Users.Find(userModel.Id);

            this.ShopData.Users.Delete(user);
            this.ShopData.SaveChanges();

            return this.Json(new[] { userModel }.ToDataSourceResult(request, this.ModelState));
        }

        public ActionResult Index()
        {
            return this.View();
        }
    }
}