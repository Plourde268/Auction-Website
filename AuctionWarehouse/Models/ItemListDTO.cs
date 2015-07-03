using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionWarehouse.Models
{
    public class ItemListDTO
    {
        public IList<ItemsDTO> ItemList { get; set; }
    }
}