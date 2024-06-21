using MediatR;
using MultiShop.Business.MediatR.Handlers;
using MultiShop.Business.MediatR.Queries;
using System.Reflection;

namespace MultiShop.Presentation.Extensions
{
    public static class MediatRServiceCollectionExtensions
    {
        public static IServiceCollection AddMediatRHandlers(this IServiceCollection services, Assembly assembly)
        {

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            // Örnek handler'ları eklemek için:
            services.AddTransient<IRequestHandler<GetProductByCategoryIdQuery, List<ProductDto>>, GetProductsByCategoryIdHandler>();
            services.AddTransient<IRequestHandler<GetSlidersQuery, List<SliderDto>>, GetSlidersQueryHandler>();
            services.AddTransient<IRequestHandler<GetCategoriesQuery, List<CategoryDto>>, GetCategoriesHandler>();
            services.AddTransient<IRequestHandler<GetSimilarProductsQuery, List<ProductDto>>, GetSimilarProductsQueryHandler>();


            // Birden fazla handler eklemek isterseniz, assembly içinden otomatik olarak tanımlayabilirsiniz:
            // services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

            return services;
        }
    }
}
