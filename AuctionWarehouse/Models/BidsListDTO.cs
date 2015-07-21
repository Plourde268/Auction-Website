using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionWarehouse.Models
{
    public class BidsListDTO
    {
        public IList<BidDTO> BidsList { get; set; }
        public string UserId { get; set; }
    }
}