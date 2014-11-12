namespace Shop.Net.Model.Cart
{
    using System;
    using System.Collections.Generic;

    public class Cart
    {
        public Cart()
        {
            this.CartItems = new HashSet<CartItem>();
        }

        public int Id { get; set; }

        public virtual ApplicationUser Customer { get; set; }

        public string CustomerId { get; set; }

        public ICollection<CartItem> CartItems { get; set; }

        public DateTime? CreatedOnUtc { get; set; }
    }
}