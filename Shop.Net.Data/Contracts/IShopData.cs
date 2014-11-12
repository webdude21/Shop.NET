namespace Shop.Net.Data.Contracts
{
    using Shop.Net.Model;
    using Shop.Net.Model.Cart;
    using Shop.Net.Model.Catalog;
    using Shop.Net.Model.Marketing;
    using Shop.Net.Model.Order;
    using Shop.Net.Model.Shipping;

    public interface IShopData
    {
        IRepository<ApplicationUser> Users { get; }

        IRepository<CartItem> CartItems { get; }

        IRepository<Product> Products { get; }

        IRepository<Category> Categories { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Review> Reviews { get; }

        IRepository<Image> Images { get; }

        IRepository<Order> Orders { get; }

        IRepository<OrderItem> OrderItems { get; }

        IRepository<Cart> ShoppingCarts { get; }

        IRepository<ContactInformation> ContactInformations { get; }

        IRepository<Country> Countries { get; }

        void SaveChanges();
    }
}