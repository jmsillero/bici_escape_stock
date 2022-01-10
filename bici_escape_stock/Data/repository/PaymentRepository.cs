using bici_escape_stock.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bici_escape_stock.Data.repository
{
    public class PaymentRepository : BaseRepository<Payment, BEscapeContext>
    {
        public PaymentRepository(BEscapeContext context) : base(context)
        {
        }

        public override async  Task<Payment> Add(Payment entity)
        {   
            context.Entry(entity.Currency).State = EntityState.Unchanged;
            context.Entry(entity.Product).State = EntityState.Unchanged;

            return await base.Add(entity);
        }

        public override async  Task<List<Payment>> GetAll()
        {
            return await context.Payment
               .Include(p => p.Product)
               .Include(p => p.Product.Currency).ToListAsync();
        }
    }
}
