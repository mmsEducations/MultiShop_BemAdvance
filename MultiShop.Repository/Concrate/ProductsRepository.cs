

namespace MultiShop.Repository
{
    public class ProductRepository : MultiShop.Repository.Repository<Product>, IProductRepository
    {
        public ProductRepository(MultiShopDbContext dbContext) : base(dbContext)
        {

        }

        public Product GetProductById(int id)
        {
            return _dbContext.Set<Product>()
                              .Include(pc => pc.Category)
                              .Include(pr => pr.ProductRatings)
                              .Include(pr => pr.ProductImages)
                              .Where(p => p.ProductID == id)
                              .FirstOrDefault();
        }


        public List<Product> GetProductsByCategoriId(int id)
        {
            return _dbContext.Set<Product>()
                              .Include(pc => pc.Category)
                              .Where(p => p.CategoryID == id)
                              .ToList();
        }

        public List<Product> GetProductsByFilter(int minPrice, int maxPrice, int sorting)
        {
            return _dbContext.Set<Product>()
                              .Include(pc => pc.Category)
                              .Include(pr => pr.ProductRatings)
                              .Take(sorting)
                              .Where(p => p.DistcountedPrice > minPrice && p.DistcountedPrice < maxPrice)
                              .ToList();
        }

        public List<Product> GetProductsWithCategory()
        {
            return _dbContext.Set<Product>()
                              .Include(pc => pc.Category)
                              .ToList();
        }


        public Task<List<Product>> GetProductsByCategoriIdAsync(int id)
        {
            return _dbContext.Set<Product>()
                            .Include(pc => pc.Category)
                            .Where(p => p.CategoryID == id)
                            .ToListAsync();
        }

        public Task<Product> GetProductByIdSync(int id)
        {
            return _dbContext.Set<Product>()
                             .Include(pc => pc.Category)
                             .Include(pr => pr.ProductRatings)
                             .Include(pr => pr.ProductImages)
                             .Where(p => p.ProductID == id)
                             .FirstOrDefaultAsync();
        }
    }

}

//Repository Design Pattern 
//önce temel Interface ve Class yazılır(base class,ve base Interface)
//Daha sonra ilgili entiity'e özel metodlar iligli entity adındaki interface'te tutulur