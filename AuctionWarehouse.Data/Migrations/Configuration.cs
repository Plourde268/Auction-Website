namespace AuctionWarehouse.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using AuctionWarehouse.Data.Model;
    using Microsoft.AspNet.Identity.EntityFramework;


    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        public string pic1 = "data:image/jpeg;base64,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";
        public string pic2 = "data:image/jpeg;base64,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";
    
    protected override void Seed(ApplicationDbContext context)
        {
            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(context);
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(userStore);

            RoleStore<Role> roleStore = new RoleStore<Role>(context);
            RoleManager<Role> roleManager = new RoleManager<Role>(roleStore);

            if (!roleManager.RoleExists("Admin"))
                roleManager.Create(new Role { Name = "Admin" });

            if (!roleManager.RoleExists("User"))
                roleManager.Create(new Role { Name = "User" });

            ApplicationUser justin = userManager.FindByName("jplou001@fiu.edu");

            if (justin == null)
            {
                justin = new ApplicationUser
                {
                    UserName = "jplou001@fiu.edu",
                    Email = "jplou001@fiu.edu"
                };
                userManager.Create(justin, "123456");
                userManager.AddToRole(justin.Id, "Admin");

                justin = userManager.FindByName("jplou001@fiu.edu");
            }

            ApplicationUser keenan = userManager.FindByName("Keenan@fiu.edu");

            if (keenan == null)
            {
                keenan = new ApplicationUser
                {
                    UserName = "Keenan@fiu.edu",
                    Email = "Keenan@fiu.edu"
                };
                userManager.Create(keenan, "123456");
                userManager.AddToRole(keenan.Id, "User");

                keenan = userManager.FindByName("Keenan@fiu.edu");
            }

            ApplicationUser david = userManager.FindByName("david@fiu.edu");

            if (david == null)
            {
                david = new ApplicationUser
                {
                    UserName = "david@fiu.edu",
                    Email = "david@fiu.edu"
                };
                userManager.Create(david, "123456");
                userManager.AddToRole(david.Id, "User");

                david = userManager.FindByName("david@fiu.edu");
            }

            context.Items.AddOrUpdate(p => p.Name,
                new Item {ItemId=1, CategoryId=2, SellerId=1, MinPrice=2.00m, Name="Phone Case", Description="Phone case shaped like a bunny rabbit", Condition= ItemCondition.Good, DateAdded=DateTime.Parse("2010-10-3"), Expiration=DateTime.Parse("2015-10-12"), ImageUrl=pic1, DateCreated=DateTime.Parse("2010-4-8"), DateUpdated=DateTime.Parse("2010-4-8"), IsDeleted=false},
                new Item { ItemId = 2, CategoryId = 1, SellerId = 2, MinPrice = 2.00m, Name = "Blackberry", Description = "Buisiness mans phone", Condition = ItemCondition.Good, DateAdded = DateTime.Parse("2011-4-13"), Expiration = DateTime.Parse("2015-12-12"), ImageUrl = pic2, DateCreated = DateTime.Parse("2010-4-13"), DateUpdated = DateTime.Parse("2013-4-13"), IsDeleted = false }
                );

            context.Bids.AddOrUpdate(p => p.Amount,
                new Bid { BidId = 1, BuyerId = 1, ItemId = 1, Amount = 237.00m, Availible = true, DateCreated = DateTime.Parse("2008-4-10"), DateUpdated = new DateTime(2008, 4, 10), IsDeleted = false },
                new Bid { BidId = 2, BuyerId = 1, ItemId = 2, Amount = 628.00m, Availible = true, DateCreated = new DateTime(2008, 4, 10), DateUpdated = new DateTime(2008, 4, 10), IsDeleted = false }
                );

            context.Buyers.AddOrUpdate(p => p.Email,
                new Buyer {BuyerId=1, FirstName="Al", LastName="Gore", Email="Al@neverpresident.com", AddressId=3, DateCreated= new DateTime(2010, 4, 13), DateUpdated=new DateTime(2010, 4, 13), IsDeleted=false, UserId=justin.Id},
                new Buyer { BuyerId = 2, FirstName = "Anna", LastName = "Cousso", Email = "Anna@fiu.edu", AddressId = 4, DateCreated = new DateTime(2010, 4, 13), DateUpdated=new DateTime(2010, 4, 13), IsDeleted=false, UserId=david.Id}
                );

            context.Sellers.AddOrUpdate(p => p.Email,
                new Seller { SellerId = 1, FirstName = "Steve", LastName = "Ballmer", Email = "Steve@microsoft.com", AddressId = 1, DateCreated = new DateTime(2008, 4, 10), DateUpdated = new DateTime(2008, 4, 10), IsDeleted = false, UserId = david.Id },
                new Seller {SellerId=2, FirstName="Mark", LastName="Cuban", Email="Mark@microsolutions.com", AddressId=2, DateCreated=new DateTime(2010, 10, 3), DateUpdated=new DateTime(2010, 10, 3), IsDeleted=false, UserId=keenan.Id}
                );

            context.Transactions.AddOrUpdate(p => p.LastFourDig,
                new Transaction {TransactionId=1, BuyerId=1, SellerId=1, Amount=237.00m, LastFourDig=1234, AddressId=3, DateCreated=new DateTime(2010, 4, 14), DateUpdated=new DateTime(2010, 4, 14), IsDeleted=false},
                new Transaction {TransactionId=2, BuyerId=1, SellerId=2, Amount=628.00m, LastFourDig=9876, AddressId=3, DateCreated=new DateTime(2010, 4, 15), DateUpdated=new DateTime(2010, 4, 15), IsDeleted=false}
                );

            context.Addresses.AddOrUpdate(p => p.Street,
                new Address {AddressId=1, Street="1111 South Figueroa Street", AptNum=null, City="Los Angeles", State="CA", Zip="90015", DateCreated=new DateTime(2008, 4, 10), DateUpdated=new DateTime(2008, 4, 10), IsDeleted=false},
                new Address {AddressId=2, Street="2500 Victory Avenue", AptNum=null, City="Dallas", State="TX", Zip="75219", DateCreated=new DateTime(2010, 10, 3), DateUpdated=new DateTime(2010, 10, 3), IsDeleted=false},
                new Address {AddressId=3, Street="732 Buckingham Street", AptNum=null, City="Watertown", State="CT", Zip="06779", DateCreated=new DateTime(2010, 4, 13), DateUpdated=new DateTime(2010, 4, 13), IsDeleted=false}
                );

            context.Categories.AddOrUpdate(p => p.CatName,
                new Category {CatergoryId=1, CatName="Technology"},
                new Category {CatergoryId=2, CatName="Accessories"}
                );


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
