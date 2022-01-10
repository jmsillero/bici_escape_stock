using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using bici_escape_stock.Models;

namespace bici_escape_stock.Models
{
    public class BEscapeContext : DbContext
    {
        // public BEscapeContext(DbContextOptions<BEscapeContext> options)
        //     : base(options)
        // {
        // }
        
        
        protected readonly IConfiguration Configuration;

        public BEscapeContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to mysql with connection string from app settings
            var connectionString = Configuration.GetConnectionString("Default");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }


        public DbSet<bici_escape_stock.Models.Currency> Currency { get; set; }

        public DbSet<bici_escape_stock.Models.Product> Product { get; set; }

        public DbSet<bici_escape_stock.Models.ProductEntry> ProductEntry { get; set; }

        public DbSet<bici_escape_stock.Models.BrokenProduct> BrokenProduct { get; set; }

        public DbSet<bici_escape_stock.Models.Payment> Payment { get; set; }

        public DbSet<bici_escape_stock.Models.Driver> Driver { get; set; }

        public DbSet<bici_escape_stock.Models.Delivery> Delivery { get; set; }

        public DbSet<bici_escape_stock.Models.DeliveryProduct> DeliveryProduct { get; set; }

        public DbSet<bici_escape_stock.Models.LeftOverProduct> LeftOverProduct { get; set; }

        public DbSet<bici_escape_stock.Models.Order> Order { get; set; }

        public DbSet<bici_escape_stock.Models.ProductOrder> ProductOrder { get; set; }

        public DbSet<bici_escape_stock.Models.Sale> Sale { get; set; }

        public DbSet<bici_escape_stock.Models.SalePayment> SalePayment { get; set; }

        public DbSet<bici_escape_stock.Models.SalePaymentValue> SalePaymentValue { get; set; }

        public DbSet<bici_escape_stock.Models.Vendor> Vendor { get; set; }

        public DbSet<bici_escape_stock.Models.VendorEntry> VendorEntry { get; set; }

        public DbSet<bici_escape_stock.Models.VendorPayment> VendorPayment { get; set; }
    }
}
