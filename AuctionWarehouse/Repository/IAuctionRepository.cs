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
        IList<BidDTO> GetBids(string id);
        void AddItem(Item item);
        void AddBid(Bid bid);
        IList<UserItemDTO> FetchUserItems(string id);
        void EditItem(Item item);
        void EditBid(Bid bid);
        void DeleteUserBid(Bid bid);
        void DeleteUserItem(Item item);
    }
}