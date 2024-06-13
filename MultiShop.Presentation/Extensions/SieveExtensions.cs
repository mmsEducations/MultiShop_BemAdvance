using MultiShop.Business.Sieve;
using Sieve.Models;
using Sieve.Services;

namespace MultiShop.Presentation.Extensions
{
    public static class SieveExtensions
    {
        public static void AddCustomSieveConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SieveOptions>(configuration.GetSection("Sieve"));
            services.AddScoped<ISieveCustomSortMethods, SieveCustomSortMethods>();
            services.AddScoped<ISieveCustomFilterMethods, SieveCustomFilterMethods>();
            services.AddScoped<ISieveProcessor, ApplicationSieveProcessor>();
        }
    }
}
