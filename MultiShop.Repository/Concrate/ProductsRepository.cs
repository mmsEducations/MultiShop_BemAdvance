namespace MultiShop.Repository
{
    public class ProductRepository : MultiShop.Repository.Repository<Product>, IProductRepository
    {
        public ProductRepository(MultiShopDbContext dbContext) : base(dbContext)
        {

        }

        public Product GetProductById(int id)
        {
            //return _dbContext.Set<Product>().Include(c => c.Category)
            //                                .Include(pr => pr.ProductRatings)
            //                                .Include(pi => pi.ProductImages)
            //                                .Where(x => x.ProductID == id)
            //.FirstOrDefault();

            return _dbContext.Set<Product>().Include("Category")
                                      .Include("ProductRatings")
                                      .Include("ProductImages")
                                       .Where(x => x.ProductID == id)
                                       .FirstOrDefault();

        }
    }



    public static partial class LinqExtension
    {
        public static IQueryable<TEntity> Include<TEntity>(
            this IQueryable<TEntity> sources,
            params Expression<Func<TEntity, object>>[] properties)
            where TEntity : class
        {
            System.Text.RegularExpressions.Regex regex = new(@"^\w+[.]");
            IQueryable<TEntity> _sources = sources;
            foreach (var property in properties)
                _sources = _sources.Include($"{regex.Replace(property.Body.ToString(), "")}");
            return _sources;
        }

        public static IQueryable<TEntity> ThenInclude<TEntity, TProperty>(
            this IQueryable<TEntity> sources,
            Expression<Func<TEntity, IEnumerable<TProperty>>> predicate,
            params Expression<Func<TProperty, object>>[] properties)
            where TEntity : class
        {
            System.Text.RegularExpressions.Regex regex = new(@"^\w+[.]");
            IQueryable<TEntity> _sources = sources;
            foreach (var property in properties)
                _sources = _sources.Include($"{regex.Replace(predicate.Body.ToString(), "")}.{regex.Replace(property.Body.ToString(), "")}");
            return _sources;
        }
    }
}

//Repository Design Pattern 
//önce temel Interface ve Class yazılır(base class,ve base Interface)
//Daha sonra ilgili entiity'e özel metodlar iligli entity adındaki interface'te tutulur