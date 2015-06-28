using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionWarehouse.Data.Model
{
    public class Category
    {
        [Key]
        public int CatergoryId { get; set; }

        public string CatName { get; set; }
    }
}
