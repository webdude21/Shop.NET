namespace Shop.Net.Web.Models.Cart
{
    using Shop.Net.Model.Catalog;
    using Shop.Net.Web.Infrastructure.Mapping;

    public class CartProductViewModel : IMapFrom<Product>
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string FriendlyUrl { get; set; }

        public string Sku { get; set; }

        public decimal Price { get; set; }
    }
}