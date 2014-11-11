namespace Shop.Net.Data
{
    using System;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Shop.Net.Model;
    using Shop.Net.Model.Catalog;
    using Shop.Net.Model.Order;
    using Shop.Net.Model.Shipping;
    using Shop.Net.Resources;

    internal class Seeder
    {
        private readonly ShopDbContext context;

        private readonly CountryLoader countryLoader;

        public Seeder(ShopDbContext context, CountryLoader countryLoader)
        {
            this.context = context;
            this.countryLoader = countryLoader;
        }

        public void SeedCountries()
        {
            if (this.context.Countries.Any())
            {
                return;
            }

            var countryList = this.countryLoader.RetrieveCountries();

            foreach (var country in countryList)
            {
                this.context.Countries.Add(new Country { Code = country.Key, Name = country.Value });
            }

            this.context.SaveChanges();
        }


        public void SeedOrders()
        {
            if (this.context.Orders.Any())
            {
                return;
            }

            for (var i = 0; i < 100; i++)
            {
                this.SeedOrder();
            }
        }

        public void SeedRolesAndUsers()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(this.context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.context));

            CreateRoleIfItDoesntExist(roleManager, GlobalConstants.AdministratorRole);
            CreateRoleIfItDoesntExist(roleManager, GlobalConstants.EmployeeRole);
            CreateRoleIfItDoesntExist(roleManager, GlobalConstants.CustomerRole);

            var user = new ApplicationUser { UserName = GlobalConstants.DefaultAdminUser };

            if (userManager.FindByName(GlobalConstants.DefaultAdminUser) == null)
            {
                var result = userManager.Create(user, GlobalConstants.DefaultAdminUser);

                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, GlobalConstants.AdministratorRole);
                }
            }

            this.context.SaveChanges();
        }

        public void SeedProducts()
        {
            if (this.context.Products.Any())
            {
                return;
            }

            var dslr = new Category
                           {
                               Name = "DSLRs", 
                               MetaTitle = "Here you can find a great variety of Dslrs.", 
                               FriendlyUrl = "dslr", 
                               MetaDescription =
                                   "A digital single-lens reflex camera (also called a digital SLR or DSLR) is a digital camera combining the optics and the mechanisms of a single-lens reflex camera with a digital imaging sensor, as opposed to photographic film. The reflex design scheme is the primary difference between a DSLR and other digital cameras. In the reflex design, light travels through the lens, then to a mirror that alternates to send the image to either the viewfinder or the image sensor. The alternative would be to have a viewfinder with its own lens, hence the term \"single lens\" for this design. By using only one lens, the viewfinder presents an image that will not perceptibly differ from what is captured by the camera's sensor."
                           };

            const string Description =
                "The D7000 sits above the D90 in Nikon's current lineup, and as befits its new position in the range, the D7000 combines elements of the D90 with elements of the D300S - Nikon's current APS-C flagship. The most obvious physical clue to its new position is a magnesium alloy body shell, which up to now has been reserved for Nikon's top-end APS-C and full frame cameras";

            this.context.Products.Add(
                new Product
                    {
                        Name = "EOS 5D mk3", 
                        Manufacturer = "Canon", 
                        Category = dslr, 
                        Published = true,
                        CreatedOnUtc = DateTime.UtcNow, 
                        UpdatedOnUtc = DateTime.UtcNow, 
                        FriendlyUrl = "canon-eos-5d-mk3", 
                        Description = Description, 
                        MetaDescription = Description,
                        Sku = Guid.NewGuid().ToString(),
                        ManufacturerPartNumber = Guid.NewGuid().ToString(),
                        MetaTitle = "Canon EOS 5D mk3", 
                        Images =
                            new[]
                                {
                                    new Image
                                        {
                                            FileName = "Canon EOS 5D mk3", 
                                            Url =
                                                "http://www.dpreview.com/reviews/CanonEOS5D/Images/frontview.jpg"
                                        }
                                }
                    });

            this.context.Products.Add(
                new Product
                    {
                        Name = "EOS 7D mk2", 
                        Manufacturer = "Canon", 
                        Category = dslr, 
                        Price = 2000,
                        Published = true,
                        FriendlyUrl = "canon-eos-7d-mk2", 
                        CreatedOnUtc = DateTime.UtcNow, 
                        UpdatedOnUtc = DateTime.UtcNow, 
                        Description = Description, 
                        MetaDescription = Description,
                        Sku = Guid.NewGuid().ToString(),
                        ManufacturerPartNumber = Guid.NewGuid().ToString(),
                        MetaTitle = "Canon EOS 5D mk3", 
                        Images =
                            new[]
                                {
                                    new Image
                                        {
                                            FileName = "Canon EOS 7D mk2", 
                                            Url =
                                                "http://www.dpreview.com/reviews/CanonEOS7D/Images/Front.jpg"
                                        }
                                }
                    });

            this.context.Products.Add(
                new Product
                    {
                        Name = "D7000", 
                        Manufacturer = "Nikon", 
                        Category = dslr, 
                        Price = 1500,
                        Published = true,
                        FriendlyUrl = "nikon-d7000", 
                        CreatedOnUtc = DateTime.UtcNow, 
                        UpdatedOnUtc = DateTime.UtcNow, 
                        Description = Description, 
                        MetaDescription = Description, 
                        MetaTitle = "Nikon D7000",
                        Sku = Guid.NewGuid().ToString(),
                        ManufacturerPartNumber = Guid.NewGuid().ToString(),
                        Images =
                            new[]
                                {
                                    new Image
                                        {
                                            FileName = "D7000 front", 
                                            Url = "http://www.kenrockwell.com/nikon/d7000/D3S_2871-1200.jpg"
                                        }, 
                                    new Image
                                        {
                                            Url = "http://www.kenrockwell.com/nikon/d7000/back-0600.jpg", 
                                            FileName = "D7000 - back"
                                        }, 
                                    new Image
                                        {
                                            Url =
                                                "http://www.kenrockwell.com/nikon/d7000/D3S_2888-top-0600.jpg", 
                                            FileName = "D7000 - top"
                                        }, 
                                    new Image
                                        {
                                            Url =
                                                "http://www.kenrockwell.com/nikon/d7000/D3S_2892-bottom-0600.jpg", 
                                            FileName = "D7000 - bottom"
                                        }
                                }
                    });

            this.context.Products.Add(
                new Product
                    {
                        Name = "D5100", 
                        Manufacturer = "Nikon", 
                        Category = dslr, 
                        Price = 700,
                        Published = true,
                        FriendlyUrl = "nikon-d5100", 
                        CreatedOnUtc = DateTime.UtcNow, 
                        UpdatedOnUtc = DateTime.UtcNow, 
                        Description = Description, 
                        Sku = Guid.NewGuid().ToString(),
                        ManufacturerPartNumber = Guid.NewGuid().ToString(),
                        MetaDescription = Description, 
                        MetaTitle = "Nikon D5100", 
                        Images =
                            new[]
                                {
                                    new Image
                                        {
                                            FileName = "D5100", 
                                            Url =
                                                "http://www.dpreview.com/reviews/NikonD5100/images/Front.jpg"
                                        }
                                }
                    });

            this.context.Products.Add(
                new Product
                    {
                        Name = "K-5", 
                        Manufacturer = "Pentax", 
                        Category = dslr, 
                        Price = 1500,
                        Published = true,
                        FriendlyUrl = "pentax-k5", 
                        CreatedOnUtc = DateTime.UtcNow, 
                        UpdatedOnUtc = DateTime.UtcNow, 
                        Description = Description, 
                        MetaDescription = Description,
                        Sku = Guid.NewGuid().ToString(),
                        ManufacturerPartNumber = Guid.NewGuid().ToString(),
                        MetaTitle = "Pentax K-5", 
                        Images =
                            new[]
                                {
                                    new Image
                                        {
                                            FileName = "Pentax K-5", 
                                            Url = "http://www.dpreview.com/reviews/pentaxk5/images/intro.jpg"
                                        }
                                }
                    });

            this.context.Products.Add(
                new Product
                    {
                        Name = "K-3", 
                        Manufacturer = "Pentax", 
                        Category = dslr, 
                        Price = 1600,
                        Published = true,
                        FriendlyUrl = "pentax-k3", 
                        CreatedOnUtc = DateTime.UtcNow, 
                        UpdatedOnUtc = DateTime.UtcNow, 
                        Description = Description, 
                        MetaDescription = Description,
                        Sku = Guid.NewGuid().ToString(),
                        ManufacturerPartNumber = Guid.NewGuid().ToString(),
                        MetaTitle = "Pentax K-3", 
                        Images =
                            new[]
                                {
                                    new Image
                                        {
                                            FileName = "Pentax K-3", 
                                            Url =
                                                "http://www.blogcdn.com/www.engadget.com/media/2013/10/pentax-k-3.jpg"
                                        }
                                }
                    });

            this.context.SaveChanges();
        }

        private void SeedOrder()
        {
            var user = this.context.Users.FirstOrDefault();
            var products = this.context.Products.ToList();
            var orderItems = products.Select((t, i) => new OrderItem { OrderedProduct = t, Quantity = i }).ToList();

            this.context.Orders.Add(
                new Order
                {
                    Customer = user,
                    OrderItems = orderItems,
                    CreatedOnUtc = DateTime.UtcNow,
                    UpdatedOnUtc = DateTime.UtcNow,
                    OrderStatus = OrderStatus.AwatingForPaymentConfirmation
                });

            this.context.SaveChanges();
        }

        private static void CreateRoleIfItDoesntExist(RoleManager<IdentityRole> roleManager, string role)
        {
            if (!roleManager.RoleExists(role))
            {
                roleManager.Create(new IdentityRole(role));
            }
        }
    }
}