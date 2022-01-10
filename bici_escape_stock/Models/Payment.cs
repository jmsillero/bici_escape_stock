using bici_escape_stock.Models.common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bici_escape_stock.Models
{
    public enum PaymentStatus { COUNTED, COMPLETED }
    [Table("payment")]
    public class Payment : IEntity
    {
        public int Id { get; set; }
        public string Description { get; set; } 
        public DateTime CreateAt { get; set; }
        public Product Product { get; set; }
        public int ProductCount { get; set; } 
        public double Amount { get; set; }
        public Currency Currency { get; set; }
        public double Rate { get; set; }
        public PaymentStatus Status { get; set; }
        public DateTime CompletedAt { get; set; }
    }
}
