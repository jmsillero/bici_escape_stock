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
    public class DeliveryProductsController : ControllerBase
    {
        private readonly BEscapeContext _context;

        public DeliveryProductsController(BEscapeContext context)
        {
            _context = context;
        }

        // GET: api/DeliveryProducts
        [HttpGet]
        public IEnumerable<DeliveryProduct> GetDeliveryProduct()
        {
            return _context.DeliveryProduct;
        }

        // GET: api/DeliveryProducts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeliveryProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deliveryProduct = await _context.DeliveryProduct.FindAsync(id);

            if (deliveryProduct == null)
            {
                return NotFound();
            }

            return Ok(deliveryProduct);
        }

        // PUT: api/DeliveryProducts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeliveryProduct([FromRoute] int id, [FromBody] DeliveryProduct deliveryProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deliveryProduct.Id)
            {
                return BadRequest();
            }

            _context.Entry(deliveryProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryProductExists(id))
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

        // POST: api/DeliveryProducts
        [HttpPost]
        public async Task<IActionResult> PostDeliveryProduct([FromBody] DeliveryProduct deliveryProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DeliveryProduct.Add(deliveryProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeliveryProduct", new { id = deliveryProduct.Id }, deliveryProduct);
        }

        // DELETE: api/DeliveryProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeliveryProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deliveryProduct = await _context.DeliveryProduct.FindAsync(id);
            if (deliveryProduct == null)
            {
                return NotFound();
            }

            _context.DeliveryProduct.Remove(deliveryProduct);
            await _context.SaveChangesAsync();

            return Ok(deliveryProduct);
        }

        private bool DeliveryProductExists(int id)
        {
            return _context.DeliveryProduct.Any(e => e.Id == id);
        }
    }
}