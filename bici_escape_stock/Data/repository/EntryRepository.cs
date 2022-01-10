using bici_escape_stock.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bici_escape_stock.Data.repository
{
    public class EntryRepository : BaseRepository<ProductEntry, BEscapeContext>
    {
        public EntryRepository(BEscapeContext context) : base(context)
        {
        }

        public override async Task<ProductEntry> Add(ProductEntry entity)
        {
            context.Entry(entity.Product).State = EntityState.Modified;
            return await base.Add(entity);
        }

        public override async Task<List<ProductEntry>> GetAll()
        {
            return await context.ProductEntry
                 .Include(e => e.Product)
                 .Include(p => p.Product.Currency).ToListAsync();
        }
    }
}
