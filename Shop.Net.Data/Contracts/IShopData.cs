namespace Shop.Net.Data.Contracts
{
    using Shop.Net.Model;

    public interface IShopData
    {
        IRepository<ApplicationUser> Users { get; }

        void SaveChanges();
    }
}