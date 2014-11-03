namespace Shop.Net.Data.Contracts
{
    using System.Linq;

    public interface IRepository<T>
        where T : class
    {
        IQueryable<T> All();

        T Find(object id);

        T Add(T entity);

        void Update(T entity);

        T Delete(T entity);

        T Delete(object id);

        int SaveChanges();
    }
}