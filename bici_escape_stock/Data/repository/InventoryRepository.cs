using bici_escape_stock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bici_escape_stock.Data.repository
{
    public class InventoryRepository
    {
        protected readonly SalesRepository salesRepository;
        protected readonly EntryRepository entryRepository;
        protected readonly ProductRepository productRepository;        protected readonly PaymentRepository paymentRepository;

        public InventoryRepository(SalesRepository salesRepository,
            EntryRepository entryRepository,
            ProductRepository productRepository,
            PaymentRepository paymentRepository)
        {
            this.salesRepository = salesRepository;
            this.entryRepository = entryRepository;
            this.productRepository = productRepository;
            this.paymentRepository = paymentRepository;
        }


        public async Task<List<Inventory>> GetAll()
        {
            List<ProductEntry> productEntries = await entryRepository.GetAll();
            List<Sale> sales = await salesRepository.GetAll();
            List<Product> products = await productRepository.GetAll();
            List<Payment> payments = await paymentRepository.GetAll();

            List<Inventory> inventories = new List<Inventory>();

            foreach (var entry in products)
            {
                List<ProductEntry> entries = productEntries.Where(x => x.Product.Id == entry.Id).ToList();
                List<Sale> productSales = sales.Where(x => x.Product.Id == entry.Id).ToList();
                List<Payment> paidOutProducts = payments.Where(x => x.Product.Id == entry.Id).ToList();

                int productCount = entries.Sum(x => x.Count);
                int soldCound = productSales.Sum(x => x.Count);

                double collected = productSales
                    .Sum(x => x.Count * (x.SalePayments
                    .Sum(sp => sp.PaymentValues
                    .Sum(pv => pv.Amount * pv.Rate))));
                
                int delivered = paidOutProducts.Sum(x => x.ProductCount );

                double paidOut = paidOutProducts.Sum(x => x.Amount * x.Rate);

                double totalSould = soldCound * entry.Cost * entry.Rate;

                Inventory inventory = new Inventory
                {
                    Product = entry,
                    Total = productCount,
                    Sold = soldCound,
                    Delivered = delivered,

                    InStock = productCount - soldCound,

                    PaidOut = paidOut,
                    Collected = collected,
                    TotalSold = totalSould,
                    CashInStock = totalSould - paidOut,
                    Profits = collected - totalSould,
                };

                inventories.Add(inventory);
            }

            return inventories;
        }

    }
}
