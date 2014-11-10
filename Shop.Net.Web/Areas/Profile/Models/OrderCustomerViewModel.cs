namespace Shop.Net.Web.Areas.Profile.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    using AutoMapper;

    using Shop.Net.Model.Order;
    using Shop.Net.Web.Infrastructure.Mapping;

    public class OrderCustomerViewModel : IMapFrom<Order>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public ICollection<OrderItemViewModel> OrderItems { get; set; }

        public OrderStatus OrderStatus { get; set; }

        [DisplayName(@"Created on")]
        public DateTime? CreatedOnUtc { get; set; }

        public decimal TotalAmmout
        {
            get
            {
                return this.OrderItems.Sum(x => x.Quantity * x.OrderedProduct.Price);
            }
        }

        public int ItemsCount
        {
            get
            {
                return this.OrderItems.Count;
            }
        }

        public int TotalQuantity
        {
            get
            {
                return this.OrderItems.Sum(i => i.Quantity);
            }
        }

        public void CreateMappings(IConfiguration configuration)
        {
        }
    }
}