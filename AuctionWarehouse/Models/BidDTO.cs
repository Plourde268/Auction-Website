using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionWarehouse.Models
{
    public class BidDTO
    {
        public int BidId { get; set; }
        public string ItemName { get; set; }
        public decimal Amount { get; set; }
        public decimal MinPrice { get; set; }
        public DateTime BidExpiration { get; set; }

        public string UserId { get; set; }
    }
}