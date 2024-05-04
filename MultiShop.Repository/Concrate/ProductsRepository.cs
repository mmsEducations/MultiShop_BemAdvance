
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
    }

}

//Repository Design Pattern 
//önce temel Interface ve Class yazılır(base class,ve base Interface)
//Daha sonra ilgili entiity'e özel metodlar iligli entity adındaki interface'te tutulur