using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionWarehouse.Models
{
    public class EditItemsListDTO
    {
        public IList<EditItemDTO> EditItemsList { get; set; }
        public string UserId { get; set; }
    }
}