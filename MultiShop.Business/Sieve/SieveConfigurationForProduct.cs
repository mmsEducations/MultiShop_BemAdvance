using Sieve.Services;

namespace MultiShop.Business.Sieve
{
    public class SieveConfigurationForProduct : ISieveConfiguration
    {
        public void Configure(SievePropertyMapper mapper)
        {
            mapper.Property<Product>(p => p.ProductName)
                 .CanFilter()
                 .HasName("ProductName");
            mapper.Property<Product>(p => p.Category.CategoryName)
                .CanFilter()
                .HasName("CategoryName");

        }
    }

}
