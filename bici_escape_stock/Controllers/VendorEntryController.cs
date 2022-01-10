using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bici_escape_stock.Data.repository;
using bici_escape_stock.domain.repository;
using bici_escape_stock.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bici_escape_stock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorEntryController : BiciEscapeController<VendorEntry, VendorEntryRepository>
    {
        public VendorEntryController(VendorEntryRepository repository) : base(repository)
        {
        }


    }
}
