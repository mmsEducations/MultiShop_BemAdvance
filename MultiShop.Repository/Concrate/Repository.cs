using Microsoft.EntityFrameworkCore.Storage;

namespace MultiShop.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly MultiShopDbContext _dbContext;
        private DbSet<TEntity> _dbset;

        public Repository(MultiShopDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbset = _dbContext.Set<TEntity>();
        }

        public TEntity? Get(int id)
        {
            return _dbset.Find(id);
        }

        public TEntity? Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbset.Where(predicate).FirstOrDefault();
        }

        public List<TEntity> GetAll()
        {
            return _dbset.AsNoTracking().ToList();
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbset.Where(predicate).ToList();
        }

        public bool Add(TEntity entity)
        {
            _dbset.Add(entity);
            return Save();
        }

        public bool AddRange(List<TEntity> entities)
        {
            _dbset.AddRange(entities);
            return Save();
        }

        public bool Remove(int id)
        {
            TEntity? entity = Get(id);
            if (entity != null)
            {
                _dbset.Remove(entity);
                return Save();
            }
            return false;
        }

        public bool RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbset.RemoveRange(entities);
            return Save();
        }

        public bool Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return Save();
        }

        public bool Save()
        {
            try
            {
                _dbContext.SaveChanges();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _dbContext.Database.BeginTransaction();
        }

        public bool CommitTransaction()
        {
            try
            {
                _dbContext.Database.CommitTransaction();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool RollbackTransaction()
        {
            try
            {
                _dbContext.Database.RollbackTransaction();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbset.AsNoTracking().ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbset.Where(predicate).AsNoTracking().ToListAsync();
        }

        public async Task<TEntity?> GetAsync(int id)
        {
            return await _dbset.FindAsync(id);
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbset.Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<bool> AddAsync(TEntity entity)
        {
            await _dbset.AddAsync(entity);
            return await SaveAsync();
        }

        public async Task<bool> AddRangeAsync(List<TEntity> entities)
        {
            await _dbset.AddRangeAsync(entities);
            return await SaveAsync();
        }

        public async Task<bool> RemoveAsync(int id)
        {
            TEntity? entity = await GetAsync(id);
            if (entity != null)
            {
                _dbset.Remove(entity);
                return await SaveAsync();
            }
            return false;
        }

        public async Task<bool> RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            _dbset.RemoveRange(entities);
            return await SaveAsync();
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return await SaveAsync();
        }

        public async Task<bool> SaveAsync()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }
    }
}
