using AuctionWarehouse.Data.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionWarehouse.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Address> Addresses { get; set; }
        public IDbSet<Bid> Bids { get; set; }
        public IDbSet<Buyer> Buyers { get; set; }
        public IDbSet<Category> Categories { get; set; }
        public IDbSet<Item> Items { get; set; }
        public IDbSet<Seller> Sellers { get; set; }
        public IDbSet<Transaction> Transactions { get; set; }



        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
