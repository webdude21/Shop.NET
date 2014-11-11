namespace Shop.Net.Model.Order
{
    using System;
    using System.Collections.Generic;

    using Shop.Net.Model.Catalog;
    using Shop.Net.Model.Shipping;

    public class Cart
    {
        public Cart()
        {
            this.Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        public virtual ApplicationUser Customer { get; set; }

        public string CustumerId { get; set; }

        public ICollection<Product> Products { get; set; }

        public ContactInformation ShippingInformation { get; set; }

        public ContactInformation BillingInformation { get; set; }

        public DateTime? CreatedOnUtc { get; set; }
    }
}