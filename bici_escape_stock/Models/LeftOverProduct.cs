using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bici_escape_stock.Models
{
    [Table("leftoverproduct")]
    public class LeftOverProduct
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Total { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
