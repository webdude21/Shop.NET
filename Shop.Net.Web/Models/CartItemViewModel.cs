namespace Shop.Net.Web.Models
{
    using Shop.Net.Model.Order;
    using Shop.Net.Web.Infrastructure.Mapping;

    public class CartItemViewModel : IMapFrom<OrderItem>
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public CartProductViewModel OrderedProduct { get; set; }

        public int OrderedProductId { get; set; }
    }
}