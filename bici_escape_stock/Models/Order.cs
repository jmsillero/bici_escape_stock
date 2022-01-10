using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bici_escape_stock.Models
{
    [Table("order")]
    public class Order
    {
        public int Id { get; set; }
        public List<ProductOrder> ProductOrders { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime EndDate { get; set; }
    }
}
