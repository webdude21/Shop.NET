namespace Shop.Net.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using Microsoft.AspNet.Identity;

    using Shop.Net.Data.Contracts;
    using Shop.Net.Model;
    using Shop.Net.Resources;
    using Shop.Net.Web.Areas.Administration.Models;
    using Shop.Net.Web.Controllers;

    public class UsersController : AdministrationController
    {
        public UsersController(IShopData shopData, UserManager<ApplicationUser> userManager)
            : base(shopData, userManager)
        {
        }

        public ActionResult Get([DataSourceRequest] DataSourceRequest request)
        {
            var users = this.ShopData.Users.All().Project().To<UserViewModel>().ToList().AsQueryable();

            foreach (var userViewModel in users)
            {
                this.FillRoles(userViewModel);
            }

            return this.Json(users.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [NonAction]
        private void FillRoles(UserViewModel userViewModel)
        {
            var roles = this.UserManager.GetRoles(userViewModel.Id);

            foreach (var role in roles)
            {
                switch (role)
                {
                    case GlobalConstants.AdministratorRole:
                        userViewModel.Administrator = true;
                        break;
                    case GlobalConstants.EmployeeRole:
                        userViewModel.Employee = true;
                        break;
                    case GlobalConstants.CustomerRole:
                        userViewModel.Customer = true;
                        break;
                }
            }
        }
    }
}