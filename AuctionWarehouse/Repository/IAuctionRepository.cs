using AuctionWarehouse.Data.Model;
using AuctionWarehouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionWarehouse.Repository
{
    public interface IAuctionRepository
    {
        IList<ItemsDTO> GetItems();
        void AddItem(Item item);
    }
}