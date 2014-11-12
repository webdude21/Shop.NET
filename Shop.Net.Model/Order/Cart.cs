namespace Shop.Net.Model.Order
{
    using System;
    using System.Collections.Generic;

    public class Cart
    {
        public Cart()
        {
            this.OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }

        public virtual ApplicationUser Customer { get; set; }

        public string CustumerId { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

        public DateTime? CreatedOnUtc { get; set; }
    }
}