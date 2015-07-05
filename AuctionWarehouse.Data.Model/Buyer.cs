using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionWarehouse.Data.Model
{
    public class Buyer : AuditObject
    {

        [Key]
        public int BuyerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int? AddressId { get; set; }
        [ForeignKey("AddressId")]
        public virtual Address ShippingAddress { get; set; }

        public IList<Item> Purchases { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    }
}
