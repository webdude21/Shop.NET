namespace Shop.Net.Web.Models
{
    using System;
    using System.Collections.Generic;

    using Shop.Net.Model.Cart;
    using Shop.Net.Web.Infrastructure.Mapping;

    public class CartViewModel : IMapFrom<Cart>
    {
        public int Id { get; set; }

        public string CustomerId { get; set; }

        public ICollection<CartItemViewModel> CartItems { get; set; }

        public DateTime? CreatedOnUtc { get; set; }
    }
}