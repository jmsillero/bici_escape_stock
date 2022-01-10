using bici_escape_stock.Models.common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bici_escape_stock.Models
{
    [Table("vendorentry")]
    public class VendorEntry : IEntity

    {
        public int Id { get; set; }
        public Vendor Vendor { get; set; }
        public Product Product { get; set; }
        public double Cost { get; set; }
        public int Count { get; set; }
        public Currency Currency { get; set; }
        public double Rate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
