using bici_escape_stock.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bici_escape_stock.Data.repository
{
    public class ProductRepository : BaseRepository<Product, BEscapeContext>
    {
        public ProductRepository(BEscapeContext context) : base(context)
        {
        }


        public override async Task<Product> Add(Product product)
        {
            context.Entry(product.Currency).State = EntityState.Unchanged;
            return await base.Add(product);
        }

        public override async Task<List<Product>> GetAll()
        {
            return await context.Product.Include(p => p.Currency).ToListAsync();
        }
    }
}
