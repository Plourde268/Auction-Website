using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionWarehouse.Data.Model
{
    public class Seller : AuditObject
    {

        [Key]
        public int SellerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int AddressId { get; set; }
        [ForeignKey("AddressId")]
        public virtual Address BillingAddress { get; set; }

    }
}
