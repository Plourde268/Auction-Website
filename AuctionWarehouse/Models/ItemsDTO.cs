using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionWarehouse.Models
{
    public class ItemsDTO
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal MinPrice { get; set; }
        public DateTime BidExpiration { get; set; }

        public string UserId { get; set; }
    }
}