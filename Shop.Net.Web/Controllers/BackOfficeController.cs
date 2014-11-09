namespace Shop.Net.Web.Controllers
{
    using System.Web.Mvc;

    using Shop.Net.Data.Contracts;
    using Shop.Net.Resources;
    using Shop.Net.Web.Infrastructure.Contracts;

    [Authorize(Roles = GlobalConstants.AdministratorRole + "," + GlobalConstants.EmployeeRole)]
    public class BackOfficeController : BaseController
    {
        public BackOfficeController(IShopData shopData, IImageUploader imageUploader)
            : base(shopData)
        {
            this.ImageUploader = imageUploader;
        }

        public IImageUploader ImageUploader { get; set; }
    }
}