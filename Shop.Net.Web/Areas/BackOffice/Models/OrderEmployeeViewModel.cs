namespace Shop.Net.Web.Areas.BackOffice.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    using global::Shop.Net.Model.Order;
    using global::Shop.Net.Web.Areas.Profile.Models;

    namespace Shop.Net.Model.Order
    {
        public class OrderEmployeeViewModel
        {

            public ApplicationUser Customer { get; set; }

            public string CustomerId { get; set; }

            public ApplicationUser ApprovedBy { get; set; }

            public string ApprovedById { get; set; }

            public int Id { get; set; }

            public virtual ICollection<OrderItemViewModel> OrderItems { get; set; }

            public OrderStatus OrderStatus { get; set; }

            public DateTime? CreatedOnUtc { get; set; }

            public DateTime? UpdatedOnUtc { get; set; }

            [NotMapped]
            public decimal TotalAmmout
            {
                get
                {
                    return this.OrderItems.Sum(x => x.Quantity * x.OrderedProduct.Price);
                }
            }

            [NotMapped]
            public decimal TotalCost
            {
                get
                {
                    return this.OrderItems.Sum(x => x.Quantity * x.OrderedProduct.ProductCost);
                }
            }

            [NotMapped]
            public decimal TotalGrossProfit
            {
                get
                {
                    return this.TotalAmmout - this.TotalCost;
                }
            }
        }
    }
}