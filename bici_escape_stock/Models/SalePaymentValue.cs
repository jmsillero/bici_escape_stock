using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bici_escape_stock.Models
{
    [Table("salepaymentvalue")]
    public class SalePaymentValue
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public Currency Currency { get; set; }
        public double Rate { get; set; }
    }
}
