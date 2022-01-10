using bici_escape_stock.Models.common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bici_escape_stock.Models
{
    [Table("vendorpayment")]
    public class VendorPayment : IEntity
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public Vendor Vendor { get; set; }
        public int Count { get; set; }
        public double Amount { get; set; }
        public DateTime DateTime { get; set; } 
        public Currency Currency { get; set; }
        public double Rate { get; set; } 
        public DateTime CreatedAt { get; set; }
    }
}
