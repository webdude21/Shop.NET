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
            context.Configuration.AutoDetectChangesEnabled = false;
            var seeder = new Seeder(context, new CountryLoader(), new RandomDataGenerator());
            seeder.SeedRolesAndUsers();
            seeder.SeedCountries();
            seeder.SeedContactInformaton(50);
            seeder.SeedCategories(15);
            seeder.SeedProducts(200);
            seeder.SeedOrders(200);
            context.Configuration.AutoDetectChangesEnabled = true;
        }
    }
}