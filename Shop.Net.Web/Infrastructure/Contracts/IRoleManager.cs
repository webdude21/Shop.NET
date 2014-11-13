namespace Shop.Net.Web.Infrastructure.Contracts
{
    using Shop.Net.Web.Areas.Administration.Models;

    public interface IRoleManager
    {
        void UpdateRoles(UserViewModel userModel);

        void FillRoles(UserViewModel userViewModel);
    }
}