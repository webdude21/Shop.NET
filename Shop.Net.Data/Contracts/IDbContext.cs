namespace Shop.Net.Data.Contracts
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Shop.Net.Model.Cart;
    using Shop.Net.Model.Catalog;
    using Shop.Net.Model.Marketing;
    using Shop.Net.Model.Order;
    using Shop.Net.Model.Shipping;

    public interface IDbContext
    {
        IDbSet<Cart> Carts { get; set; }

        IDbSet<Country> Countries { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Review> Reviews { get; set; }

        IDbSet<Product> Products { get; set; }

        IDbSet<Image> Images { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<Order> Orders { get; set; }

        IDbSet<OrderItem> OrderItems { get; set; }

        IDbSet<ContactInformation> ContactInformations { get; set; }

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        IDbSet<T> Set<T>() where T : class;

        int SaveChanges();
    }
}