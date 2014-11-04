namespace Shop.Net.Model.Order
{
    using System;
    using System.Collections.Generic;

    using Shop.Net.Model.Catalog;

    public class Order
    {
        public Order()
        {
            this.Products = new HashSet<Product>();
        }

        public ApplicationUser Customer { get; set; }

        public ApplicationUser ApprovedBy { get; set; }

        public int Id { get; set; }

        public ICollection<Product> Products { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public DateTime? CreatedOnUtc { get; set; }

        public DateTime? UpdatedOnUtc { get; set; }
    }
}