namespace Shop.Net.Data.Contracts
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Shop.Net.Model.Shipping;

    public interface IDbContext
    {
        IDbSet<Country> Countries { get; set; }

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        IDbSet<T> Set<T>() where T : class;

        int SaveChanges();
    }
}