using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bici_escape_stock.Models;

namespace bici_escape_stock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalePaymentsController : ControllerBase
    {
        private readonly BEscapeContext _context;

        public SalePaymentsController(BEscapeContext context)
        {
            _context = context;
        }

        // GET: api/SalePayments
        [HttpGet]
        public IEnumerable<SalePayment> GetSalePayment()
        {
            return _context.SalePayment;
        }

        // GET: api/SalePayments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSalePayment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var salePayment = await _context.SalePayment.FindAsync(id);

            if (salePayment == null)
            {
                return NotFound();
            }

            return Ok(salePayment);
        }

        // PUT: api/SalePayments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalePayment([FromRoute] int id, [FromBody] SalePayment salePayment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != salePayment.Id)
            {
                return BadRequest();
            }

            _context.Entry(salePayment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalePaymentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SalePayments
        [HttpPost]
        public async Task<IActionResult> PostSalePayment([FromBody] SalePayment salePayment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SalePayment.Add(salePayment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalePayment", new { id = salePayment.Id }, salePayment);
        }

        // DELETE: api/SalePayments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalePayment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var salePayment = await _context.SalePayment.FindAsync(id);
            if (salePayment == null)
            {
                return NotFound();
            }

            _context.SalePayment.Remove(salePayment);
            await _context.SaveChangesAsync();

            return Ok(salePayment);
        }

        private bool SalePaymentExists(int id)
        {
            return _context.SalePayment.Any(e => e.Id == id);
        }
    }
}