namespace Shop.Net.Web.Areas.BackOffice.Models
{
    using global::Shop.Net.Model.Order;
    using global::Shop.Net.Web.Infrastructure.Mapping;

    public class OrderItemEmployeeViewModel : IMapFrom<Order>
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public ProductEditModel OrderedProduct { get; set; }

        public int OrderedProductId { get; set; }
    }
}