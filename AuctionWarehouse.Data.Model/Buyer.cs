using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionWarehouse.Data.Model
{
    public class Buyer
    {
        public Buyer()
        {
            this.BillingAddress = new Address();
            this.ShippingAddress = new Address();
        }

        [Key]
        public int BuyerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public Address BillingAddress { get; set; }

        public Address ShippingAddress { get; set; }

        //public string UserName { get; set; }

        //public string Password { get; set; }
    }
}
