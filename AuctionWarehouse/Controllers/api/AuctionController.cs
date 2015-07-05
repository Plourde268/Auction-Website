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
        //IList<Item> items = new List<Item>
        //    {
        //        new Item {Name="Hair Brush", Description="Soft Brisles", Category = new Category{CatName="Feminine Products"}},
        //        new Item {Name="Banana Holder", Description="Holds up to 12 bananas", Category = new Category{CatName="Fruit accessories"}},
        //        new Item {Name="mouse", Description="wireless", Category = new Category{CatName="Computer"}}
        //    };
        public AuctionController()
            : this(new AuctionRepository())
        {

        }
        public AuctionController(IAuctionRepository repo)
        {
            _repo = repo;
        }

        public ItemListDTO Get()
        {
            ItemListDTO items = new ItemListDTO();

            items.ItemList = _repo.GetItems();

            return items;
        }

        [HttpPost]
        public bool Post(Item item)
        {
            if (ModelState.IsValid)
            {
                string userId = User.Identity.GetUserId();
                item.CreatedUserId = userId;
                item.UpdatedUserId = userId;
                item.SellerId = 1;

                _repo.AddItem(item);
                

            }
            return true;
        }
    }
}
