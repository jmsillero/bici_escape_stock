using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bici_escape_stock.Models;
using bici_escape_stock.Data.repository;
using bici_escape_stock.domain.repository;

namespace bici_escape_stock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BiciEscapeController<Product, ProductRepository>
    {
        public ProductsController(ProductRepository repository) : base(repository)
        {
        }

        //// GET api/inventory
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<TEntity>>> GetInventory()
        //{
        //    return await repository.GetAll();
        //}

    }
}