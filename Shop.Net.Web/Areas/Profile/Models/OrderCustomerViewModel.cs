namespace Shop.Net.Web.Areas.Profile.Models
{
    using System.Collections.Generic;
    using System.Linq;

    using Shop.Net.Model.Order;
    using Shop.Net.Web.Areas.Catalog.Models.Product;
    using Shop.Net.Web.Infrastructure.Mapping;

    public class OrderCustomerViewModel : IMapFrom<Order>
    {
        public int Id { get; set; }

        public ICollection<ProductThumbnailModel> Products { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public decimal TotalAmmout
        {
            get
            {
                return this.Products.Sum(p => p.Price);
            }
        }
    }
}