namespace Shop.Net.Web.Areas.BackOffice.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using Shop.Net.Model.Order;
    using Shop.Net.Web.Infrastructure.Mapping;
    using Shop.Net.Web.Models;

    public class OrderEmployeeViewModel : IMapFrom<Order>, IHaveCustomMappings
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public string Customer { get; set; }

        [ScaffoldColumn(false)]
        public string CustomerId { get; set; }

        public virtual CarrierViewModel Carrier { get; set; }

        public virtual ICollection<OrderItemEmployeeViewModel> OrderItems { get; set; }

        public OrderStatus OrderStatus { get; set; }

        [DisplayName(@"Created On")]
        public DateTime? CreatedOnUtc { get; set; }

        public DateTime? UpdatedOnUtc { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Order, OrderEmployeeViewModel>()
               .ForMember(model => model.Customer, opt => opt.MapFrom(fullProduct => fullProduct.Customer.UserName));
        }
    }
}