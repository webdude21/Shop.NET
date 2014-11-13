namespace Shop.Net.Web.Areas.Administration.Models
{
    using Shop.Net.Model;
    using Shop.Net.Web.Infrastructure.Mapping;

    public class UserViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public bool Administrator { get; set; }

        public bool Employee { get; set; }

        public bool Customer { get; set; }
    }
}