using bici_escape_stock.Models;
using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Extensions.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bici_escape_stock.Data.repository
{
    public class VendorRepository : BaseRepository<Vendor, BEscapeContext>
    {
        public VendorRepository(BEscapeContext context) : base(context)
        {
        }

        public async Task<List<VendorEntry>> GetVendorEntries(int id)
        {
            var data = await context.VendorEntry
                .Include(x => x.Product)
                .Include(x => x.Currency)
                .Include(x => x.Product.Currency)
                .Where(x => x.Vendor.Id == id)
                .ToListAsync();
            return data;
        }

        public async Task<List<VendorPayment>> GetVendorPayments(int id)
        {
            var data = await context.VendorPayment
                .Include(x => x.Product)
                .Include(x => x.Currency)
                .Include(x => x.Product.Currency)
                .Where(x => x.Vendor.Id == id)
                .ToListAsync();

            return data;
        }
    }
}