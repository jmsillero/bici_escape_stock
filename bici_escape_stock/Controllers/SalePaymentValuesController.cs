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
    public class SalePaymentValuesController : ControllerBase
    {
        private readonly BEscapeContext _context;

        public SalePaymentValuesController(BEscapeContext context)
        {
            _context = context;
        }

        // GET: api/SalePaymentValues
        [HttpGet]
        public IEnumerable<SalePaymentValue> GetSalePaymentValue()
        {
            return _context.SalePaymentValue;
        }

        // GET: api/SalePaymentValues/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSalePaymentValue([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var salePaymentValue = await _context.SalePaymentValue.FindAsync(id);

            if (salePaymentValue == null)
            {
                return NotFound();
            }

            return Ok(salePaymentValue);
        }

        // PUT: api/SalePaymentValues/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalePaymentValue([FromRoute] int id, [FromBody] SalePaymentValue salePaymentValue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != salePaymentValue.Id)
            {
                return BadRequest();
            }

            _context.Entry(salePaymentValue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalePaymentValueExists(id))
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

        // POST: api/SalePaymentValues
        [HttpPost]
        public async Task<IActionResult> PostSalePaymentValue([FromBody] SalePaymentValue salePaymentValue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SalePaymentValue.Add(salePaymentValue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalePaymentValue", new { id = salePaymentValue.Id }, salePaymentValue);
        }

        // DELETE: api/SalePaymentValues/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalePaymentValue([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var salePaymentValue = await _context.SalePaymentValue.FindAsync(id);
            if (salePaymentValue == null)
            {
                return NotFound();
            }

            _context.SalePaymentValue.Remove(salePaymentValue);
            await _context.SaveChangesAsync();

            return Ok(salePaymentValue);
        }

        private bool SalePaymentValueExists(int id)
        {
            return _context.SalePaymentValue.Any(e => e.Id == id);
        }
    }
}