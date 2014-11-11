namespace Shop.Net.Web.Areas.BackOffice.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    using AutoMapper;

    using Shop.Net.Model.Order;
    using Shop.Net.Web.Infrastructure.Mapping;

    public class OrderEmployeeViewModel : IMapFrom<Order>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Customer { get; set; }

        public string CustomerId { get; set; }

        public string ApprovedBy { get; set; }

        public string ApprovedById { get; set; }

        public virtual ICollection<OrderItemEmployeeViewModel> OrderItems { get; set; }

        public OrderStatus OrderStatus { get; set; }

        [DisplayName(@"Created On")]
        public DateTime? CreatedOnUtc { get; set; }

        public DateTime? UpdatedOnUtc { get; set; }

        public decimal TotalAmmout
        {
            get
            {
                return this.OrderItems.Sum(x => x.Quantity * x.OrderedProduct.Price);
            }
        }

        public decimal TotalCost
        {
            get
            {
                return this.OrderItems.Sum(x => x.Quantity * x.OrderedProduct.ProductCost);
            }
        }

        public decimal TotalGrossProfit
        {
            get
            {
                return this.TotalAmmout - this.TotalCost;
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
            configuration.CreateMap<Order, OrderEmployeeViewModel>()
               .ForMember(model => model.Customer, opt => opt.MapFrom(fullProduct => fullProduct.Customer.UserName));

            configuration.CreateMap<Order, OrderEmployeeViewModel>()
               .ForMember(model => model.ApprovedBy, opt => opt.MapFrom(fullProduct => fullProduct.ApprovedBy.UserName));
        }
    }
}