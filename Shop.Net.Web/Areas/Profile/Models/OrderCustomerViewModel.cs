namespace Shop.Net.Web.Areas.Profile.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    using AutoMapper;

    using Shop.Net.Model.Order;
    using Shop.Net.Web.Infrastructure.Mapping;
    using Shop.Net.Web.Models;

    public class OrderCustomerViewModel : IMapFrom<Order>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public ICollection<OrderItemViewModel> OrderItems { get; set; }

        public virtual CarrierViewModel Carrier { get; set; }

        public OrderStatus OrderStatus { get; set; }

        [DisplayName(@"Created on")]
        public DateTime? CreatedOnUtc { get; set; }

        public string TotalAmmout
        {
            get
            {
                var total = this.OrderItems.Sum(x => x.Quantity * x.OrderedProduct.Price) + this.Carrier.DeliveryPrice;
                return total.ToString("C");
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

        public DateTime? ExpectedDelivery
        {
            get
            {
                return this.CreatedOnUtc.GetValueOrDefault(DateTime.Now).AddDays(this.Carrier.DeliverInDays);
            }
        }

        public void CreateMappings(IConfiguration configuration)
        {
        }
    }
}