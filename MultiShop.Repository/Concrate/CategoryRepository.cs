using MultiShop.Data;

namespace MultiShop.Repository
{
    public class CategoryRepository : MultiShop.Repository.Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(MultiShopDbContext dbContext) : base(dbContext)
        {

        }

        public void GetTopThreeCategory()
        {
            throw new NotImplementedException();
        }
    }
}

//Repository Design Pattern 
//önce temel Interface ve Class yazılır(base class,ve base Interface)
//Daha sonra ilgili entiity'e özel metodlar iligli entity adındaki interface'te tutulur