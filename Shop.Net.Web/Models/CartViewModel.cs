namespace Shop.Net.Web.Models
{
    using System;
    using System.Collections.Generic;

    using Shop.Net.Model.Cart;
    using Shop.Net.Model.Order;
    using Shop.Net.Web.Infrastructure.Mapping;

    public class CartViewModel : IMapFrom<Cart>
    {
        public int Id { get; set; }

        public string CustumerId { get; set; }

        public ICollection<CartItemViewModel> OrderItems { get; set; }

        public DateTime? CreatedOnUtc { get; set; }
    }
}