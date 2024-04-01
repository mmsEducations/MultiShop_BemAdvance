using System.Linq.Expressions;

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
    }
}
