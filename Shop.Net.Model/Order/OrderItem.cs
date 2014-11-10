namespace Shop.Net.Model.Order
{
    using Shop.Net.Model.Catalog;

    public class OrderItem
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public Product OrderedProduct { get; set; }

        public int OrderedProductId { get; set; }
    }
}