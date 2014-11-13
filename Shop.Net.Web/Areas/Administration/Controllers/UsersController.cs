namespace Shop.Net.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

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

        public ActionResult Index()
        {
            var usersAndRoles = this.ShopData.Users.All().Project().To<UserViewModel>();

            foreach (var userViewModel in usersAndRoles)
            {
                this.FillRoles(userViewModel);
            }

            return this.View(usersAndRoles);
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
                        userViewModel.Employee = true;
                        break;
                }
            }
        }
    }
}