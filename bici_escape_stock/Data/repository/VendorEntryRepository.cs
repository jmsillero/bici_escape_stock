using bici_escape_stock.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bici_escape_stock.Data.repository
{
    public class VendorEntryRepository : BaseRepository<VendorEntry, BEscapeContext>
    {
        public VendorEntryRepository(BEscapeContext context) : base(context)
        {
        }

        public override async Task<VendorEntry> Add(VendorEntry entity)
        {
            context.Entry(entity.Currency).State = EntityState.Unchanged;
            context.Entry(entity.Product).State = EntityState.Unchanged;
            context.Entry(entity.Vendor).State = EntityState.Unchanged;

            return await base.Add(entity);
        }

        public override async Task<List<VendorEntry>> GetAll()
        {
            return await context.VendorEntry
               .Include(p => p.Product)
               .Include(p => p.Product.Currency).ToListAsync();
        }
    }
}
