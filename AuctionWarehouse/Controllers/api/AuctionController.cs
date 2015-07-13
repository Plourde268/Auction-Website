using AuctionWarehouse.Data.Model;
using AuctionWarehouse.Models;
using AuctionWarehouse.Repository;
using AuctionWarehouse.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace AuctionWarehouse.Controllers.api
{
    public class AuctionController : ApiController
    {
        private IAuctionRepository _repo; 
        
       
        public AuctionController()
            : this(new AuctionRepository())
        {

        }
        public AuctionController(IAuctionRepository repo)
        {
            _repo = repo;
        }

        [Authorize]
        public ItemListDTO Get()
        {

            ItemListDTO items = new ItemListDTO();
            string userId = User.Identity.GetUserId();
            
            items.ItemList = _repo.GetItems();
            
            return items;
        }

        [HttpPost]
        //[Authorize(Roles="Admin")]
        public bool Post(Item item)
        {
            if (ModelState.IsValid)
            {
                string userId = User.Identity.GetUserId();
                
                item.CreatedUserId = userId;
                item.UpdatedUserId = userId;
                
                
                _repo.AddItem(item);

            }
            return true;
        }
    }
}
