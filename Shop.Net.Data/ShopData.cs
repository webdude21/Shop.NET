namespace Shop.Net.Data
{
    using System;
    using System.Collections.Generic;

    using Shop.Net.Data.Contracts;
    using Shop.Net.Data.Repositories;
    using Shop.Net.Model;

    internal class ShopData
    {
        private readonly IDbContext context;

        private readonly IDictionary<Type, object> repositories;

        public LaptopSystemData()
            : this(new ShopDbContext())
        {
        }

        public LaptopSystemData(IDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<ApplicationUser> Users
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);

            if (this.repositories.ContainsKey(typeOfModel))
            {
                return (EfRepository<T>)this.repositories[typeOfModel];
            }

            var type = typeof(EfRepository<T>);

            this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));

            return (EfRepository<T>)this.repositories[typeOfModel];
        }
    }
}