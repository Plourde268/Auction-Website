using AuctionWarehouse.Data;
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

        
    }
}