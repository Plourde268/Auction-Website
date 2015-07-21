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
    [Authorize]
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
        [AllowAnonymous]
        [Route("api/Auction/Get")]
        public ItemListDTO Get()
        {
            ItemListDTO items = new ItemListDTO();
            string userId = User.Identity.GetUserId();
            items.ItemList = _repo.GetItems();
            return items;
        }
        [HttpGet]
        [Route("api/Auction/FetchBids")]
        public BidsListDTO FetchBids()
        {
            BidsListDTO bids = new BidsListDTO();
            string userId = User.Identity.GetUserId();
            bids.UserId = userId;
            bids.BidsList = _repo.GetBids(userId);
            return bids;
        }
        [HttpGet]
        [Route("api/Auction/GetUserItems")]
        public UserItemListDTO GetUserItems()
        {
            UserItemListDTO items = new UserItemListDTO();
            string userId = User.Identity.GetUserId();
            items.UserId = userId;
            items.UserItemsList = _repo.FetchUserItems(userId);
            return items;
        }
        [HttpPost]
        [Route("api/Auction/Post")]
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
        [HttpPost]
        [Route("api/Auction/PostBid")]
        public bool PostBid(Bid bid)
        {
            if (ModelState.IsValid)
            {
                string userId = User.Identity.GetUserId();
                bid.CreatedUserId = userId;
                bid.UpdatedUserId = userId;
                _repo.AddBid(bid);
            }
            return true;
        }
        [HttpPut]
        [Route("api/Auction/PutItem")]
        public bool PutItem(Item item)
        {
            if (ModelState.IsValid)
            {
                string userId = User.Identity.GetUserId();
                item.CreatedUserId = userId;
                item.UpdatedUserId = userId;
                _repo.EditItem(item);
            }
            return true;
        }
        [HttpPut]
        [Route("api/Auction/PutBid")]
        public bool PutBid(Bid bid)
        {
            if (ModelState.IsValid)
            {
                string userId = User.Identity.GetUserId();
                bid.CreatedUserId = userId;
                bid.UpdatedUserId = userId;
                _repo.EditBid(bid);
            }
            return true;
        }
        [HttpPatch]
        [Route("api/Auction/DeleteBid")]
        public bool DeleteBid(Bid bid)
        {
            _repo.DeleteUserBid(bid);
            return true;
        }
        [HttpPatch]
        [Route("api/Auction/DeleteItem")]
        public bool DeleteItem(Item item)
        {
            _repo.DeleteUserItem(item);
            return true;
        }
    }
}
