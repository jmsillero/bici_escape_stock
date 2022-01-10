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
    public class VendorController : BiciEscapeController<Vendor, VendorRepository>
    {
        private VendorRepository vendorRepository;

        public VendorController(VendorRepository repository) : base(repository)
        {
            this.vendorRepository = repository;
        }

        [HttpGet("{id}/vendorentry")]
        public async Task<ActionResult<List<VendorEntry>>> GetVendorEntries(int id)
        {
            var entity = await vendorRepository.GetVendorEntries(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;
        }

        [HttpGet("{id}/vendorpayment")]
        public async Task<ActionResult<List<VendorPayment>>> GetVendorPayments(int id)
        {
            var entity = await vendorRepository.GetVendorPayments(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;
        }
    }
}
