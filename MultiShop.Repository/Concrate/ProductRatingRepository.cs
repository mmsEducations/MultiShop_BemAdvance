
namespace MultiShop.Repository
{
    public class ProductRatingRepository : MultiShop.Repository.Repository<ProductRating>, IProductRatingRepository
    {
        public ProductRatingRepository(MultiShopDbContext dbContext) : base(dbContext)
        {

        }
    }


}

//Repository Design Pattern 
//önce temel Interface ve Class yazılır(base class,ve base Interface)
//Daha sonra ilgili entiity'e özel metodlar iligli entity adındaki interface'te tutulur