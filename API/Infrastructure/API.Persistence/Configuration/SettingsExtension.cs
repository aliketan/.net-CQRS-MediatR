using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Persistence.Configuration
{
    public static partial class ServiceExtension
    {
        public static void ConfigureSettings<T>(this IServiceCollection services, IConfiguration configuration) where T: class
        {
            services.Configure<T>(configuration);
        }
    }
}
