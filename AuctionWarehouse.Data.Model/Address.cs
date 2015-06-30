using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionWarehouse.Data.Model
{
    public class Address : AuditObject
    {
        [Key]
        public int AddressId { get; set; }

        public string Street { get; set; }

        public int? AptNum { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }
    }
}
