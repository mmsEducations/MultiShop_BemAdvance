
namespace MultiShop.Repository
{
    public class CustomerRepository : MultiShop.Repository.Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(MultiShopDbContext dbContext) : base(dbContext)
        {

        }
    }


}

//Repository Design Pattern 
//önce temel Interface ve Class yazılır(base class,ve base Interface)
//Daha sonra ilgili entiity'e özel metodlar iligli entity adındaki interface'te tutulur