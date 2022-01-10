using bici_escape_stock.Models.common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bici_escape_stock.Models
{
    public enum SaleSource { PROVIDER, LEFTOVER }
    public enum SalePaymentStatus { PENDING, PAID_OUT, PARTIAL_PAID }
    [Table("sale")]
    public class Sale : IEntity
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public SaleSource Source { get; set; }
        public DateTime CreatedAt { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public string Description { get; set; }
        public List<SalePayment> SalePayments { get; set; }
        public int Count { get; set; }

    }
}
