using Application.Specification;

namespace Application.Repository
{
    public interface IGenericRepository<T, K> where T : IIdentity<K> where K : IComparable<K>
    {
        Task<T?> GetByIdAsync(K id);
        Task<List<T>> GetAllAsync();

        T? GetById(K id);

        List<T> GetAll();
        T Add(T o);

        void RemoveById(K id);

        void Update(K id, T o);

        IEnumerable<T> GetBySpecification(ISpecification<T> specification = null);
    }
}
