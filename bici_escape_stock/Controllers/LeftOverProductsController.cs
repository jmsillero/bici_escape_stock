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
    public class LeftOverProductsController : ControllerBase
    {
        private readonly BEscapeContext _context;

        public LeftOverProductsController(BEscapeContext context)
        {
            _context = context;
        }

        // GET: api/LeftOverProducts
        [HttpGet]
        public IEnumerable<LeftOverProduct> GetLeftOverProduct()
        {
            return _context.LeftOverProduct;
        }

        // GET: api/LeftOverProducts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLeftOverProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var leftOverProduct = await _context.LeftOverProduct.FindAsync(id);

            if (leftOverProduct == null)
            {
                return NotFound();
            }

            return Ok(leftOverProduct);
        }

        // PUT: api/LeftOverProducts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeftOverProduct([FromRoute] int id, [FromBody] LeftOverProduct leftOverProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != leftOverProduct.Id)
            {
                return BadRequest();
            }

            _context.Entry(leftOverProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeftOverProductExists(id))
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

        // POST: api/LeftOverProducts
        [HttpPost]
        public async Task<IActionResult> PostLeftOverProduct([FromBody] LeftOverProduct leftOverProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.LeftOverProduct.Add(leftOverProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLeftOverProduct", new { id = leftOverProduct.Id }, leftOverProduct);
        }

        // DELETE: api/LeftOverProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeftOverProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var leftOverProduct = await _context.LeftOverProduct.FindAsync(id);
            if (leftOverProduct == null)
            {
                return NotFound();
            }

            _context.LeftOverProduct.Remove(leftOverProduct);
            await _context.SaveChangesAsync();

            return Ok(leftOverProduct);
        }

        private bool LeftOverProductExists(int id)
        {
            return _context.LeftOverProduct.Any(e => e.Id == id);
        }
    }
}