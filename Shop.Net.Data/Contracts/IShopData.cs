namespace Shop.Net.Data.Contracts
{
    using Shop.Net.Model;
    using Shop.Net.Model.Catalog;
    using Shop.Net.Model.Marketing;
    using Shop.Net.Model.Order;

    public interface IShopData
    {
        IRepository<ApplicationUser> Users { get; }

        IRepository<Product> Products { get; }

        IRepository<Category> Categories { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Review> Reviews { get; }

        IRepository<Image> Images { get; }

        IRepository<Order> Orders { get; } 

        void SaveChanges();
    }
}