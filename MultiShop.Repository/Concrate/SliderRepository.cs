using MultiShop.Data;

namespace MultiShop.Repository
{
    public class SliderRepository : MultiShop.Repository.Repository<Slider>, ISliderRepository
    {
        public SliderRepository(MultiShopDbContext dbContext) : base(dbContext)
        {
        }
    }
}

//Repository Design Pattern 
//önce temel Interface ve Class yazılır(base class,ve base Interface)
//Daha sonra ilgili entiity'e özel metodlar iligli entity adındaki interface'te tutulur

//XRepostory -> IXRepository