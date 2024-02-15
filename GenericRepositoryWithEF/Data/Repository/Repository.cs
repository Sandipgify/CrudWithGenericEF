using GenericRepositoryWithEF.Data.Interface;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Threading;

namespace GenericRepositoryWithEF.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _dbContext;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> AddAsync(T t)
        {
            var entry = await _dbContext.Set<T>().AddAsync(t);
            return entry.Entity;
        }

        public void Delete(T t)
        {
            _dbContext.Remove(t);
        }

        public async Task<IEnumerable<T>> GetAllAsync(Func<T, bool> predicate = null, CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (predicate is not null)
            {
                query.Where(predicate).AsQueryable();
            }
            return await query.ToListAsync(cancellationToken);
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await _dbContext.FindAsync<T>(id);
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task SaveAsync()
        {
           await _dbContext.SaveChangesAsync();
        }
    }

    public class ReadOnlyRepository<T>: IReadOnlyRepository<T> where T : class
    {
        private readonly DbContext _dbContext;

        public ReadOnlyRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> Get(Func<T, bool> predicate = null, CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if(predicate is not null)
            {
                query.Where(predicate).AsQueryable();
            }
            return await query.AsNoTracking().FirstOrDefaultAsync<T>(cancellationToken);
        }
        public async Task<IEnumerable<T>> GetAll(Func<T, bool> predicate = null, CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (predicate is not null)
            {
                query.Where(predicate).AsQueryable();
            }
            return await query.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<bool> AnyAsync(Func<T, bool> predicate = null, CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (predicate != null)
            {
                query = query.Where(predicate).AsQueryable();
            }
            return await query.AsNoTracking().AnyAsync(cancellationToken);

        }
    }
}
