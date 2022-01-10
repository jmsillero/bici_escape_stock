using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bici_escape_stock.domain.repository;
using bici_escape_stock.Models.common;
using Microsoft.AspNetCore.Mvc;

namespace bici_escape_stock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BiciEscapeController<TEntity, TRepository> : ControllerBase where TEntity : class, IEntity
        where TRepository : IBaseRepository<TEntity>
    {

        protected readonly IBaseRepository<TEntity> repository;

        protected BiciEscapeController(IBaseRepository<TEntity> repository)
        {
            this.repository = repository;
        }


        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> Get()
        {
            return await repository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> Get(int id)
        {
            var entity = await repository.Get(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<TEntity>> Post([FromBody] TEntity value)
        {
            await repository.Add(value);
            return CreatedAtAction("Get", new { id = value.Id }, value);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult<TEntity>> Put(int id, [FromBody] TEntity value)
        {
            if (id != value.Id)
            {
                return BadRequest();
            }
            await repository.Update(value);
            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TEntity>> Delete(int id)
        {
            var entity = await repository.Delete(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;
        }
    }
}
