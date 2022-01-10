using bici_escape_stock.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bici_escape_stock.Data.repository
{
    public class SalesRepository : BaseRepository<Sale, BEscapeContext>
    {
        public SalesRepository(BEscapeContext context) : base(context)
        {
        }

        public override async Task<Sale> Add(Sale sale)
        {
            context.Entry(sale.Product).State = EntityState.Unchanged;
            foreach (SalePayment payment in sale.SalePayments)
            {
                foreach (var value in payment.PaymentValues)
                {
                    context.Entry(value.Currency).State = EntityState.Unchanged;
                }

            }
            return await base.Add(sale);
        }

        public override async Task<List<Sale>> GetAll()
        {
            return await context?.Sale
                .Include(p => p.Product)
                .Include(p => p.Product.Currency)
                .Include(p => p.SalePayments)
                .ThenInclude(x => x.PaymentValues).
                ToListAsync()!;

        }
    }
}
