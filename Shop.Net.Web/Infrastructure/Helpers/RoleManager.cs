namespace Shop.Net.Web.Infrastructure.Helpers
{
    using System.Collections.Generic;
    using System.Data.Entity;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Shop.Net.Model;
    using Shop.Net.Resources;
    using Shop.Net.Web.Areas.Administration.Models;
    using Shop.Net.Web.Infrastructure.Contracts;

    public class RoleManager : IRoleManager
    {
        public RoleManager(DbContext databaseContext)
        {
            this.DbContext = databaseContext;
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.DbContext));
        }

        public UserManager<ApplicationUser> UserManager { get; set; }

        public DbContext DbContext { get; set; }

        public void FillRoles(UserViewModel userViewModel)
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

        public void UpdateRoles(UserViewModel userModel)
        {
            var user = this.UserManager.FindById(userModel.Id);
            var roles = new List<string>();

            if (userModel.Administrator)
            {
                roles.Add(GlobalConstants.AdministratorRole);
            }

            if (userModel.Employee)
            {
                roles.Add(GlobalConstants.EmployeeRole);
            }

            if (userModel.Customer)
            {
                roles.Add(GlobalConstants.CustomerRole);
            }

            this.UserManager.RemoveFromRoles(
                user.Id, 
                new[] { GlobalConstants.AdministratorRole, GlobalConstants.CustomerRole, GlobalConstants.EmployeeRole });
            this.UserManager.AddToRoles(user.Id, roles.ToArray());
            this.DbContext.SaveChanges();
        }
    }
}