namespace MultiShop.Business
{
    public class BaseDto<Dto> where Dto : class
    {
        public Dto DtoTye { get; set; }
    }
}
