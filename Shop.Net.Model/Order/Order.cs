namespace Shop.Net.Model.Order
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class Order
    {
        private ICollection<OrderItem> orderItems;

        public Order()
        {
            this.orderItems = new HashSet<OrderItem>();
        }

        public ApplicationUser Customer { get; set; }

        public string CustomerId { get; set; }

        public ApplicationUser ApprovedBy { get; set; }

        public string ApprovedById { get; set; }

        public int Id { get; set; }

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

        public OrderStatus OrderStatus { get; set; }

        public DateTime? CreatedOnUtc { get; set; }

        public DateTime? UpdatedOnUtc { get; set; }

    }
}