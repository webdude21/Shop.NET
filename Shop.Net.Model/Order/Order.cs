namespace Shop.Net.Model.Order
{
    using System;
    using System.Collections.Generic;

    using Shop.Net.Model.Shipping;

    public class Order
    {
        private ICollection<OrderItem> orderItems;

        public Order()
        {
            this.orderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }

        public virtual ApplicationUser Customer { get; set; }

        public string CustomerId { get; set; }

        public virtual ContactInformation ShippingInformation { get; set; }

        public int ShippingInformationId { get; set; }

        public virtual Carrier Carrier { get; set; }

        public int CarrierId { get; set; }

        public virtual ICollection<OrderItem> OrderItems
        {
            get
            {
                return this.orderItems;
            }

            set
            {
                this.orderItems = value;
            }
        }

        public virtual OrderStatus OrderStatus { get; set; }

        public DateTime? CreatedOnUtc { get; set; }

        public DateTime? UpdatedOnUtc { get; set; }
    }
}