using Microsoft.EntityFrameworkCore.Storage;

namespace MultiShop.Repository
{
    //Tüm enitityler için ortak olan metodların imzalarını barındırır 
    public interface IRepository<TEntity> where TEntity : class
    {
        List<TEntity> GetAll();//List<Product>,List<Slider>
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate); //Where kısmında bulunan şart ifadesi'ni generic hale getiriyoruz 
        TEntity? Get(int id);// Product/Slider
        TEntity? Get(Expression<Func<TEntity, bool>> predicate);//Where kısmında bulunan şart ifadesi'ni generic hale getiriyoruz
        bool Add(TEntity entity);
        bool AddRange(List<TEntity> entities);
        bool Remove(int id);
        bool RemoveRange(IEnumerable<TEntity> entities);

        bool Update(TEntity entity);

        bool Save();

        public IDbContextTransaction BeginTransaction();
        public bool CommitTransaction();
        public bool RollbackTransaction();


        // Asenkron metotlar
        Task<List<TEntity>> GetAllAsync();
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity?> GetAsync(int id);
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<bool> AddAsync(TEntity entity);
        Task<bool> AddRangeAsync(List<TEntity> entities);
        Task<bool> RemoveAsync(int id);
        Task<bool> RemoveRangeAsync(IEnumerable<TEntity> entities);
        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> SaveAsync();
    }
}
