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
            return _db.Items.Select(p => new ItemsDTO
            {
                Name = p.Name,
                Description = p.Description,
                CategoryName = p.Category.CatName
            }).ToList();
        }

        public void AddItem(Item item)
        {
            item.DateCreated = DateTime.Now;
            item.DateAdded = DateTime.Now;
            item.Expiration = DateTime.Now.AddDays(7);
            item.DateUpdated = DateTime.Now;
            item.SellerId = _db.Sellers.FirstOrDefault(p => p.UserId == item.CreatedUserId).SellerId;
            _db.Items.Add(item);
            _db.SaveChanges();
        }
        
        
    }
}