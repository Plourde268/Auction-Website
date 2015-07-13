using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionWarehouse.Data.Model
{
    public class Item : AuditObject
    {
        [Key]
        public int ItemId { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public int SellerId { get; set; }
        [ForeignKey("SellerId")]
        public Seller Seller { get; set; }

        public decimal MinPrice { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime Expiration { get; set; }

        public ItemCondition Condition { get; set; }

        public string ImageUrl { get; set; }
    }

    public enum ItemCondition
    {
        New,
        Good,
        Fair
    }
}
