namespace Application.Interfaces
{
    public interface IEntityService<T>
    {
        public T Add(T entity);
        public void Update(int id, T entity);
        public Task<List<T>> FindAllAsync();
        public Task<T> FindByIdAsync(int id);
        public void Remove(int id);
    }
}