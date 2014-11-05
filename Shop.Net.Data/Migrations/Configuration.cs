namespace Shop.Net.Data.Migrations
{
    using System.Data.Entity.Migrations;

    using Shop.Net.Resources;

    internal sealed class Configuration : DbMigrationsConfiguration<ShopDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ShopDbContext context)
        {
            var seeder = new Seeder(context, new CountryLoader());
            seeder.SeedRolesAndUsers();
            seeder.SeedCountries();
            seeder.SeedProducts();
        }
    }
}