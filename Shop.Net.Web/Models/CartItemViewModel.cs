﻿namespace Shop.Net.Web.Models
{
    using Shop.Net.Model.Cart;
    using Shop.Net.Web.Infrastructure.Mapping;

    public class CartItemViewModel : IMapFrom<CartItem>
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public CartProductViewModel OrderedProduct { get; set; }

        public int OrderedProductId { get; set; }
    }
}