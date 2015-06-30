using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionWarehouse.Data.Model
{
    public abstract class AuditObject
    {
        public DateTime DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        public bool IsDeleted { get; set; }
    }
}
