using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bici_escape_stock.Models
{
    public class Inventory
    {
        public Product Product { get; set; }
        public int InStock { get; set; }
        public int Sold { get; set; }
        public int Delivered { get; set; }
        public int Total { get; set; }

        /// <summary>
        /// Total collected by all soulds 
        /// </summary>
        public double Collected { get; set; }

        /// <summary>
        /// Amount of money delivered
        /// </summary>
        public double PaidOut { get; set; }

        /// <summary>
        /// Represent the profits as result of difference between total collected and total sould
        /// </summary>
        public double Profits { get; set; }

        /// <summary>
        /// Amount of money in stock to be delivered
        /// </summary>
        public double TotalSold { get; set; }

        /// <summary>
        /// Current Amount of cash in the stock, after delivered and sold
        /// </summary>
        public double CashInStock { get; set; }

    }
}
