using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Common;
using Application.Repository;
using Application.Specification;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenericController<T, TKey> : ControllerBase where T : BaseEntity<TKey>, IIdentity<TKey> where TKey : IComparable<TKey>
    {
        private readonly IGenericRepository<T, TKey> _repository;

        public GenericController(IGenericRepository<T, TKey> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<T>>> Get()
        {
            var entities = await _repository.GetAllAsync();
            return Ok(entities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<T>> Get(TKey id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpPost]
        public ActionResult<T> Create(T entity)
        {
            var createdEntity = _repository.Add(entity);
            return CreatedAtAction(nameof(Get), new { id = createdEntity.Id }, createdEntity);
        }

        [HttpPut("{id}")]
        public IActionResult Update(TKey id, T entity)
        {
            _repository.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(TKey id)
        {
            _repository.RemoveById(id);
            return NoContent();
        }
    }
}
