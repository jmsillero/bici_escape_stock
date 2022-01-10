using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bici_escape_stock.Models
{
    [Table("salepayment")]
    public class SalePayment
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public List<SalePaymentValue> PaymentValues { get; set; }
    }
}
