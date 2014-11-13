namespace Shop.Net.Model.Order
{
    using Shop.Net.Model.Catalog;

    public class OrderItem
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public virtual Order Order { get; set; }

        public int OrderId { get; set; }

        public virtual Product OrderedProduct { get; set; }

        public int OrderedProductId { get; set; }
    }
}