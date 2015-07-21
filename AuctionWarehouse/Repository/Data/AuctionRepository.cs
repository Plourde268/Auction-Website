using AuctionWarehouse.Data;
using AuctionWarehouse.Data.Model;
using AuctionWarehouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionWarehouse.Repository.Data
{
    public class AuctionRepository : IAuctionRepository
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        public IList<ItemsDTO> GetItems()
        {
            return _db.Items.Where(e=>e.IsDeleted != true).Select(p => new ItemsDTO
            {
                ItemId = p.ItemId,
                Name = p.Name,
                Description = p.Description,
                MinPrice = p.MinPrice,
                BidExpiration = p.Expiration
            }).ToList();
        }

        public IList<BidDTO> GetBids(string userId)
        {
            return _db.Bids.Where(b => b.Buyer.UserId == userId && b.IsDeleted != true).Select(p => new BidDTO
            {
                BidId = p.BidId,
                ItemName = p.Item.Name,
                Amount = p.Amount,
                MinPrice = p.Item.MinPrice,
                BidExpiration = p.Item.Expiration
            }).ToList();
        }

        public IList<UserItemDTO> FetchUserItems(string userId)
        {
            return _db.Items.Where(p => p.Seller.UserId == userId && p.IsDeleted != true).Select(i => new UserItemDTO
            {
                ItemId = i.ItemId,
                Name = i.Name,
                Description = i.Description,
                MinPrice = i.MinPrice,
                BidExpiration = i.Expiration
            }).ToList();
        }

        public void AddItem(Item item)
        {
            item.DateCreated = DateTime.Now;
            item.DateAdded = DateTime.Now;
            item.Expiration = DateTime.Now.AddDays(7);
            item.DateUpdated = DateTime.Now;
            item.CategoryId = 1;
            item.SellerId = _db.Sellers.FirstOrDefault(p => p.UserId == item.CreatedUserId).SellerId;
            _db.Items.Add(item);
            _db.SaveChanges();
        }

        public void AddBid(Bid bid)
        {
            bid.Availible = true;
            bid.DateCreated = DateTime.Now;
            bid.DateUpdated = DateTime.Now;
            bid.IsDeleted = false;
            bid.BuyerId = _db.Buyers.FirstOrDefault(p => p.UserId == bid.CreatedUserId).BuyerId;

            _db.Bids.Add(bid);
            _db.SaveChanges();
        }

        public Item FindItem(int id)
        {
            return _db.Items.Find(id);
        }

        public Bid FindBid(int id)
        {
            return _db.Bids.Find(id);
        }

        public void EditItem(Item item)
        {
            var originalItem = this.FindItem(item.ItemId);
            originalItem.Name = item.Name;
            originalItem.Description = item.Description;
            originalItem.MinPrice = item.MinPrice;
            //originalItem.Expiration = item.BidExpiration;
            _db.SaveChanges();
        }

        public void EditBid(Bid bid)
        {
            var originalBid = this.FindBid(bid.BidId);
            originalBid.Amount = bid.Amount;
            _db.SaveChanges();
        }

        public void DeleteUserBid(Bid bid)
        {
            bid.IsDeleted = true;
            _db.SaveChanges();
        }

        public void DeleteUserItem(Item item)
        {
            item.IsDeleted = true;
            _db.SaveChanges();
        }
    }
}