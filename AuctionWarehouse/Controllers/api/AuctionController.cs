using AuctionWarehouse.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AuctionWarehouse.Controllers.api
{
    public class AuctionController : ApiController
    {

        IList<Item> items = new List<Item>
            {
                new Item {Name="Hair Brush", Description="Soft Brisles", Category = new Category{CatName="Feminine Products"}},
                new Item {Name="Banana Holder", Description="Holds up to 12 bananas", Category = new Category{CatName="Fruit accessories"}},
                new Item {Name="mouse", Description="wireless", Category = new Category{CatName="Computer"}}
            };

        static AuctionController()
        {

        }

        public IList<Item> Get()
        {
            
            return items;
        }

        public bool Post(Item item)
        {
            if (ModelState.IsValid)
            {
                items.Add(item);
                //.SaveChanges();
                
            }
            return true;
        }
    }
}
