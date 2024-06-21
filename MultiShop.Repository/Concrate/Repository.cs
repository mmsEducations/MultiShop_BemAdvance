﻿
using Microsoft.EntityFrameworkCore.Storage;

namespace MultiShop.Repository
{
    //Repository<TEntity> Generic bir class
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
            return _dbset.Find(id);//_dbContext.Set<Category>()
        }

        public TEntity? Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbset.Where(predicate).FirstOrDefault();
        }

        public List<TEntity> GetAll()
        {
            return _dbset.AsNoTracking().ToList();
        }
        //public List<TEntity> GetAllAsNotracking()
        //{
        //    return _dbset.AsNoTracking().ToList();
        //}

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbset.Where(predicate).ToList();
        }

        public bool Add(TEntity entity)
        {
            _dbset.Add(entity);
            return Save();
        }

        public bool AddRange(List<TEntity> entities)//Bir demet veri
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

        //---
        public Task<List<TEntity>> GetAllAsync()
        {
            return _dbset.AsNoTracking().ToListAsync();
        }
    }
}

//AsNoTracking: metodu ilgili entity üzerinde sadece veri okurken kullanılması gereken bir metottur ?
/*
 Neden kullanır? ?performans için kullanılır 
 */