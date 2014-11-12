namespace Shop.Net.Model.Cart
{
    using Shop.Net.Model.Catalog;

    public class CartItem
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public virtual Cart Cart { get; set; }

        public int CartId { get; set; }

        public Product OrderedProduct { get; set; }

        public int OrderedProductId { get; set; }
    }
}