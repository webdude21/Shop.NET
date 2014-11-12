namespace Shop.Net.Web.Areas.Profile.Models
{
    using Shop.Net.Model.Order;
    using Shop.Net.Web.Areas.Catalog.Models.Product;
    using Shop.Net.Web.Infrastructure.Mapping;

    public class OrderItemViewModel : IMapFrom<OrderItem>
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public ProductDetailsViewModel OrderedProduct { get; set; }

        public int OrderedProductId { get; set; }

    }
}