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
    public class ProductOrdersController : ControllerBase
    {
        private readonly BEscapeContext _context;

        public ProductOrdersController(BEscapeContext context)
        {
            _context = context;
        }

        // GET: api/ProductOrders
        [HttpGet]
        public IEnumerable<ProductOrder> GetProductOrder()
        {
            return _context.ProductOrder;
        }

        // GET: api/ProductOrders/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductOrder([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productOrder = await _context.ProductOrder.FindAsync(id);

            if (productOrder == null)
            {
                return NotFound();
            }

            return Ok(productOrder);
        }

        // PUT: api/ProductOrders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductOrder([FromRoute] int id, [FromBody] ProductOrder productOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(productOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductOrderExists(id))
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

        // POST: api/ProductOrders
        [HttpPost]
        public async Task<IActionResult> PostProductOrder([FromBody] ProductOrder productOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProductOrder.Add(productOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductOrder", new { id = productOrder.Id }, productOrder);
        }

        // DELETE: api/ProductOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductOrder([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productOrder = await _context.ProductOrder.FindAsync(id);
            if (productOrder == null)
            {
                return NotFound();
            }

            _context.ProductOrder.Remove(productOrder);
            await _context.SaveChangesAsync();

            return Ok(productOrder);
        }

        private bool ProductOrderExists(int id)
        {
            return _context.ProductOrder.Any(e => e.Id == id);
        }
    }
}