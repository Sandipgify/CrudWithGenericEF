namespace GenericRepositoryWithEF.Data.Interface
{
    public interface IRepository<T> where T: class
    {
        Task<T> AddAsync(T t);
        void Delete(T t);
        void Update(T t);
        Task<T> GetByIdAsync(object id);
        Task<IEnumerable<T>> GetAllAsync(Func<T, bool> predicate = null, CancellationToken cancellationToken = default);
        Task SaveAsync();
    }

    public interface IReadOnlyRepository<T> where T: class
    {
        Task<IEnumerable<T>> GetAll(Func<T, bool> predicate = null, CancellationToken cancellationToken = default);
        Task<T> Get(Func<T, bool> predicate = null, CancellationToken cancellationToken = default);
        Task<bool> AnyAsync(Func<T, bool> predicate = null, CancellationToken cancellationToken = default);
        }
}
