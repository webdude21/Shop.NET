namespace Shop.Net.Web.Areas.Profile.Models
{
    using Shop.Net.Model.Shipping;
    using Shop.Net.Web.Infrastructure.Mapping;

    public class CountryViewModel : IMapFrom<Country>
    {
        public string Code { get; set; }

        public string Name { get; set; }
    }
}