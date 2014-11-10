namespace Shop.Net.Model.Order
{
    using System;
    using System.Collections.Generic;

    using Shop.Net.Model.Catalog;

    public class Cart
    {
        public Cart()
        {
            this.Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        public virtual ApplicationUser Customer { get; set; }

        public int CustumerId { get; set; }

        public ICollection<Product> Products { get; set; }

        public DateTime? CreatedOnUtc { get; set; }
    }
}