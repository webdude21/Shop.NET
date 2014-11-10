namespace Shop.Net.Model.Order
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    using Shop.Net.Model.Catalog;

    public class Order
    {
        private ICollection<Product> products;

        public Order()
        {
            this.products = new HashSet<Product>();
        }

        public ApplicationUser Customer { get; set; }

        public string CustomerId { get; set; }

        public ApplicationUser ApprovedBy { get; set; }

        public string ApprovedById { get; set; }

        public int Id { get; set; }

        public virtual ICollection<Product> Products
        {
            get
            {
                return this.products;
            }
            set
            {
                this.products = value;
            }
        }

        public OrderStatus OrderStatus { get; set; }

        public DateTime? CreatedOnUtc { get; set; }

        public DateTime? UpdatedOnUtc { get; set; }

        [NotMapped]
        public decimal TotalAmmout
        {
            get
            {
                return this.products.Sum(p => p.Price);
            }
        }

        [NotMapped]
        public decimal TotalCost
        {
            get
            {
                return this.products.Sum(p => p.ProductCost);
            }
        }

        [NotMapped]

        public decimal TotalGrossProfit
        {
            get
            {
                return this.TotalAmmout - TotalCost;
            }
        }
    }
}