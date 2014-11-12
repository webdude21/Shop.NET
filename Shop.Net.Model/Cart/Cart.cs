namespace Shop.Net.Model.Cart
{
    using System;
    using System.Collections.Generic;

    public class Cart
    {
        private ICollection<CartItem> cartItems;

        public Cart()
        {
            this.cartItems = new HashSet<CartItem>();
        }

        public int Id { get; set; }

        public virtual ApplicationUser Customer { get; set; }

        public string CustomerId { get; set; }

        public virtual ICollection<CartItem> CartItems
        {
            get
            {
                return this.cartItems;
            }
            set
            {
                this.cartItems = value;
            }
        }

        public DateTime? CreatedOnUtc { get; set; }
    }
}