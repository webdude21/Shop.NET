namespace Shop.Net.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Shop.Net.Model;
    using Shop.Net.Model.Catalog;
    using Shop.Net.Model.Order;
    using Shop.Net.Model.Shipping;
    using Shop.Net.Resources;
    using Shop.Net.Resources.Contracts;

    internal class Seeder
    {
        private readonly ShopDbContext context;

        private readonly CountryLoader countryLoader;

        private readonly IRandomDataGenerator randomDataGenerator;

        public Seeder(ShopDbContext context, CountryLoader countryLoader, IRandomDataGenerator randomDataGenerator)
        {
            this.context = context;
            this.countryLoader = countryLoader;
            this.randomDataGenerator = randomDataGenerator;
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

        public void SeedCarrier()
        {
            if (this.context.Carriers.Any())
            {
                return;
            }

            this.context.Carriers.Add(new Carrier { Name = "Egmont Express", DeliveryPrice = 5.4m, DeliverInDays = 1 });

            this.context.Carriers.Add(new Carrier { Name = "Speedy Gonzalez", DeliveryPrice = 4.6m, DeliverInDays = 2 });

            this.context.Carriers.Add(new Carrier { Name = "Puma Express", DeliveryPrice = 3.8m, DeliverInDays = 1 });

            this.context.Carriers.Add(new Carrier { Name = "Outer Logistics", DeliveryPrice = 3.4m, DeliverInDays = 3 });

            this.context.Carriers.Add(new Carrier { Name = "Postal services", DeliveryPrice = 2.4m, DeliverInDays = 6 });

            this.context.SaveChanges();
        }

        public void SeedOrders(int count)
        {
            if (this.context.Orders.Any())
            {
                return;
            }

            var contactInfo = this.context.ContactInformations.ToList();
            var user = this.context.Users.FirstOrDefault();
            var carriers = this.context.Carriers.ToList();
            var products = this.context.Products.ToList();
            var items =
                products.Select(product => new OrderItem { OrderedProduct = product, Quantity = this.randomDataGenerator.GetInt(1, 5) }).ToList();

            const int OrderItemsPerOrder = 5;

            for (var i = 3; i < count; i++)
            {
                if (i % OrderItemsPerOrder == 0)
                {
                    this.SeedOrder(user, items.GetRange(i - OrderItemsPerOrder, OrderItemsPerOrder), carriers, contactInfo);
                }
            }

            this.context.SaveChanges();
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

        public void SeedContactInformaton(int count)
        {
            var user = this.context.Users.FirstOrDefault();

            if (user == null || user.Adresses.Any())
            {
                return;
            }

            var countries = this.context.Countries.ToList();

            for (var i = 0; i < count; i++)
            {
                user.Adresses.Add(
                    new ContactInformation
                        {
                            ContactName = this.randomDataGenerator.GetString(4, 40),
                            ContactPerson = this.randomDataGenerator.GetString(10, 40),
                            Address1 = this.randomDataGenerator.GetString(10, 40),
                            City = this.randomDataGenerator.GetString(10, 40),
                            PhoneNumber = this.randomDataGenerator.GetString(10, 40),
                            StateProvince = this.randomDataGenerator.GetString(10, 40),
                            ZipCode = this.randomDataGenerator.GetString(3, 16),
                            Country =
                                countries[this.randomDataGenerator.GetInt(0, countries.Count - 1)].Name,
                            Company = this.randomDataGenerator.GetString(10, 40),
                        });
            }

            this.context.SaveChanges();
        }

        public void SeedCategories(int count)
        {
            for (var i = 0; i < count; i++)
            {
                this.context.Categories.Add(new Category
                        {
                            Name = this.randomDataGenerator.GetString(15, 150),
                            MetaTitle = this.randomDataGenerator.GetString(14, 40),
                            FriendlyUrl = this.randomDataGenerator.GetUrlSafeString(15, 35),
                            MetaDescription = this.randomDataGenerator.GetString(150, 1500),
                        });
            }

            this.context.SaveChanges();
        }

        public void SeedProducts(int count)
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

            this.SeedRandomProducts(count);
            this.context.SaveChanges();
        }

        private static void CreateRoleIfItDoesntExist(RoleManager<IdentityRole, string> roleManager, string role)
        {
            if (!roleManager.RoleExists(role))
            {
                roleManager.Create(new IdentityRole(role));
            }
        }

        private Image[] GetImages()
        {
            return new[]
                       {
                           new Image
                               {
                                   FileName = this.randomDataGenerator.GetString(4, 40), 
                                   Url = "http://www.kenrockwell.com/nikon/d7000/D3S_2871-1200.jpg"
                               }, 
                           new Image
                               {
                                   Url = "http://www.kenrockwell.com/nikon/d7000/back-0600.jpg", 
                                   FileName = this.randomDataGenerator.GetString(4, 40), 
                               }, 
                           new Image
                               {
                                   Url = "http://www.kenrockwell.com/nikon/d7000/D3S_2888-top-0600.jpg", 
                                   FileName = this.randomDataGenerator.GetString(4, 40), 
                               }, 
                           new Image
                               {
                                   Url = "http://www.kenrockwell.com/nikon/d7000/D3S_2892-bottom-0600.jpg", 
                                   FileName = this.randomDataGenerator.GetString(4, 40), 
                               }
                       };
        }

        private void SeedRandomProducts(int count)
        {
            var categories = this.context.Categories.ToList();

            for (var i = 0; i < count; i++)
            {
                this.SeedRandomProduct(categories);
            }

            this.context.SaveChanges();
        }

        private void SeedRandomProduct(IReadOnlyList<Category> categories)
        {
            this.context.Products.Add(
                new Product
                    {
                        Name = this.randomDataGenerator.GetString(4, 40),
                        Manufacturer = this.randomDataGenerator.GetString(4, 40),
                        Published = true,
                        CreatedOnUtc = this.randomDataGenerator.GeneraDateTime(),
                        UpdatedOnUtc = DateTime.UtcNow,
                        Category = categories[this.randomDataGenerator.GetInt(0, categories.Count - 1)],
                        FriendlyUrl = this.randomDataGenerator.GetUrlSafeString(20, 40),
                        Description = this.randomDataGenerator.GetString(200, 350),
                        MetaDescription = this.randomDataGenerator.GetString(200, 350),
                        Sku = Guid.NewGuid().ToString(),
                        ManufacturerPartNumber = Guid.NewGuid().ToString(),
                        MetaTitle = this.randomDataGenerator.GetString(14, 40),
                        Images = this.GetImages(),
                        Price = this.randomDataGenerator.GetInt(500, 5000),
                        ProductCost = this.randomDataGenerator.GetInt(500, 5000),
                    });
        }

        private void SeedOrder(ApplicationUser user, ICollection<OrderItem> orderItems, IReadOnlyList<Carrier> carriers, List<ContactInformation> contactInfo)
        {
            this.context.Orders.Add(
                new Order
                    {
                        Customer = user,
                        OrderItems = orderItems,
                        Carrier = carriers[this.randomDataGenerator.GetInt(0, carriers.Count - 1)],
                        ShippingInformation = contactInfo[this.randomDataGenerator.GetInt(0, carriers.Count - 1)],
                        CreatedOnUtc = this.randomDataGenerator.GeneraDateTime(),
                        UpdatedOnUtc = DateTime.UtcNow, 
                        OrderStatus = (OrderStatus)this.randomDataGenerator.GetInt(0, 6),
                    });
        }
    }
}