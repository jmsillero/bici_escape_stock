using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bici_escape_stock.Data.repository;
using bici_escape_stock.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bici_escape_stock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        protected InventoryRepository inventoryRepository;

        public InventoryController(InventoryRepository inventoryRepository)
        {
            this.inventoryRepository = inventoryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inventory>>> Get()
        {
            return await inventoryRepository.GetAll();
        }
    }
}