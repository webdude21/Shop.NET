namespace Shop.Net.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Shop.Net.Data.Contracts;
    using Shop.Net.Data.Migrations;
    using Shop.Net.Model;
    using Shop.Net.Model.Shipping;

    public class ShopDbContext : IdentityDbContext<ApplicationUser>, IDbContext
    {
        public ShopDbContext()
            : base("DefaultConnection", false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ShopDbContext, Configuration>());
        }

        public IDbSet<Country> Countries { get; set; }

        public static ShopDbContext Create()
        {
            return new ShopDbContext();
        }


        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}