using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionWarehouse.Models
{
    public class EditItemDTO
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Availible { get; set; }
        public DateTime BidExpiration { get; set; }

        public string UserId { get; set; }
    }
}