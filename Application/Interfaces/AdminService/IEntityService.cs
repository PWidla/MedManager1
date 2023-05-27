namespace Application.Interfaces
{
    public interface IEntityService<T>
    {
        public T Add(T entity);
        public void Update(int id, T entity);
        public List<T> FindAll();
        public T FindById(int id);
        public void Remove(int id);
    }
}