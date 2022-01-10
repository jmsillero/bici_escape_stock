using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bici_escape_stock.Models
{

    public enum DeliveryStatus { OPEN, ACCEPTED, IN_PROGRESS, COMPLETED, CANCELLED }
    [Table("delivery")]
    public class Delivery
    {
        public int Id { get; set; }
        public Driver Driver { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string ContactAddress { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeliveryAt { get; set; }
        public DateTime CompletedAt { get; set; }
        public DeliveryStatus Status { get; set; }
        public string Description { get; set; }
        public double DeliveryFee { get; set; } 
    }
}
