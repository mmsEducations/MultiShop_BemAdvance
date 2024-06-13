namespace MultiShop.Presentation.Extensions
{
    public static class AutoMapperExtensions
    {
        public static void AddCustomAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ProductMappingProfile));
            services.AddAutoMapper(typeof(CategoryMappingProfile));
            services.AddAutoMapper(typeof(SliderMappingProfile));
            services.AddAutoMapper(typeof(CustomerMappingProfile));
            services.AddAutoMapper(typeof(OrderMappingProfile));
            services.AddAutoMapper(typeof(OrderDetailMappingProfile));
        }
    }
}
