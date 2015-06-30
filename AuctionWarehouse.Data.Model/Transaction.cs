using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionWarehouse.Data.Model
{
    public class Transaction : AuditObject
    {
        [Key]
        public int TransactionId { get; set; }

        public int BuyerId { get; set; }
        [ForeignKey("BuyerId")]
        public virtual Buyer Buyer { get; set; }

        public int SellerId { get; set; }
        [ForeignKey("SellerId")]
        public virtual Seller Seller { get; set; }

        public decimal Amount { get; set; }

        public int LastFourDig { get; set; }

        public int AddressId { get; set; }
        [ForeignKey("AddressId")]
        public virtual Address BillingAddress { get; set; }

       
    }
}
