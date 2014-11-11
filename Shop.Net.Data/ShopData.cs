namespace Shop.Net.Data
{
    using System;
    using System.Collections.Generic;

    using Shop.Net.Data.Contracts;
    using Shop.Net.Data.Repositories;
    using Shop.Net.Model;
    using Shop.Net.Model.Catalog;
    using Shop.Net.Model.Marketing;
    using Shop.Net.Model.Order;
    using Shop.Net.Model.Shipping;

    public class ShopData : IShopData
    {
        private readonly IDbContext context;

        private readonly IDictionary<Type, object> repositories;

        public ShopData(IDbContext context)
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

        public IRepository<Product> Products
        {
            get
            {
                return this.GetRepository<Product>();
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                return this.GetRepository<Category>();
            }
        }

        public IRepository<Comment> Comments
        {
            get
            {
                return this.GetRepository<Comment>();
            }
        }

        public IRepository<Review> Reviews
        {
            get
            {
                return this.GetRepository<Review>();
            }
        }

        public IRepository<Supplier> Manufacturers
        {
            get
            {
                return this.GetRepository<Supplier>();
            }
        }

        public IRepository<Image> Images
        {
            get
            {
                return this.GetRepository<Image>();
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                return this.GetRepository<Order>();
            }
        }

        public IRepository<OrderItem> OrderItems
        {
            get
            {
                return this.GetRepository<OrderItem>();
            }
        }

        public IRepository<ContactInformation> ContactInformations
        {
            get
            {
                return this.GetRepository<ContactInformation>();
            }
        }

        public IRepository<Country> Countries
        {
            get
            {
                return this.GetRepository<Country>();
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