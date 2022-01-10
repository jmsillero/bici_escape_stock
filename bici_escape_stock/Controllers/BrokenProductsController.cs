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
    public class BrokenProductsController : ControllerBase
    {
        private readonly BEscapeContext _context;

        public BrokenProductsController(BEscapeContext context)
        {
            _context = context;
        }

        // GET: api/BrokenProducts
        [HttpGet]
        public IEnumerable<BrokenProduct> GetBrokenProduct()
        {
            return _context.BrokenProduct;
        }

        // GET: api/BrokenProducts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrokenProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var brokenProduct = await _context.BrokenProduct.FindAsync(id);

            if (brokenProduct == null)
            {
                return NotFound();
            }

            return Ok(brokenProduct);
        }

        // PUT: api/BrokenProducts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrokenProduct([FromRoute] int id, [FromBody] BrokenProduct brokenProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != brokenProduct.Id)
            {
                return BadRequest();
            }

            _context.Entry(brokenProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrokenProductExists(id))
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

        // POST: api/BrokenProducts
        [HttpPost]
        public async Task<IActionResult> PostBrokenProduct([FromBody] BrokenProduct brokenProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.BrokenProduct.Add(brokenProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBrokenProduct", new { id = brokenProduct.Id }, brokenProduct);
        }

        // DELETE: api/BrokenProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrokenProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var brokenProduct = await _context.BrokenProduct.FindAsync(id);
            if (brokenProduct == null)
            {
                return NotFound();
            }

            _context.BrokenProduct.Remove(brokenProduct);
            await _context.SaveChangesAsync();

            return Ok(brokenProduct);
        }

        private bool BrokenProductExists(int id)
        {
            return _context.BrokenProduct.Any(e => e.Id == id);
        }
    }
}