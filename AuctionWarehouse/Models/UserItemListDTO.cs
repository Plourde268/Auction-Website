using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionWarehouse.Models
{
    public class UserItemListDTO
    {
        public IList<UserItemDTO> UserItemsList { get; set; }
        public string UserId { get; set; }
    }
}