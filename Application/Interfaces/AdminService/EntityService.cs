using Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.AdminService
{
    internal class EntityService<T> : IEntityService<T> where T : IIdentity<int>
    {
        private readonly IGenericRepository<T, int> _repository;

        public EntityService(IGenericRepository<T, int> repository)
        {
            _repository = repository;
        }

        public T Add(T entity)
        {
            return _repository.Add(entity);
        }

        public Task<List<T>> FindAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public async Task<T> FindByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public void Remove(int id)
        {
            _repository.RemoveById(id);
        }

        public void Update(int id, T entity)
        {
            _repository.Update(id, entity);
        }
    }
}
