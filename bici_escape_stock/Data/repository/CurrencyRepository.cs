using bici_escape_stock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bici_escape_stock.Data.repository
{
    public class CurrencyRepository : BaseRepository<Currency, BEscapeContext>
    {
        public CurrencyRepository(BEscapeContext context) : base(context)
        {
        }
    }
}
