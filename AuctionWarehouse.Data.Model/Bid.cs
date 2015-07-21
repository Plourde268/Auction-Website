using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionWarehouse.Data.Model
{
    public class Bid : AuditObject
    {
        [Key]
        public int BidId { get; set; }

        public int BuyerId { get; set; }
        [ForeignKey("BuyerId")]
        public virtual Buyer Buyer { get; set; }

        public int ItemId { get; set; }
        [ForeignKey("ItemId")]
        public virtual Item Item { get; set; }

        public decimal Amount { get; set; }

        public bool Availible { get; set; }
    }
}
