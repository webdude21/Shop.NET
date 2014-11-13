namespace Shop.Net.Web.Models.Checkout
{
    using Shop.Net.Model.Shipping;
    using Shop.Net.Web.Infrastructure.Mapping;

    public class ContactInformationDropdownViewModel : IMapFrom<ContactInformation>
    {
        public int Id { get; set; }

        public string ContactName { get; set; }
    }
}