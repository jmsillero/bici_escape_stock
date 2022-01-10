using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bici_escape_stock.Models
{
    public enum BrokenStatus
    {
        RETURNED, NOT_RETURNED
    }
    [Table("brokenproduct")]
    public class BrokenProduct
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime ReturnedAt { get; set; }

        public BrokenStatus Status { get; set; }

        public string Description { get; set; }

        public Product Product { get; set; }
    }
}
