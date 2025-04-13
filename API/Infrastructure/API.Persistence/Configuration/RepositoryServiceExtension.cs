using Microsoft.Extensions.DependencyInjection;

namespace API.Persistence.Configuration
{
    using Data;

    public static partial class ServiceExtension
    {
        public static void ConfigureRepository(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
