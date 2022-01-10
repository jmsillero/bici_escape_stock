using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bici_escape_stock.Models
{
    
    [Table("deliveryproduct")]
    public class DeliveryProduct
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public Currency Currency { get; set; }
        public double Rate { get; set; }
    }
}
