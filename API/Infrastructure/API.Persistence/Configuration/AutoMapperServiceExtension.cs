using Microsoft.Extensions.DependencyInjection;

namespace API.Persistence.Configuration
{
    public static partial class ServiceExtension
    {
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(q => q.GetName().Name == "API.Business").ToArray();
            services.AddAutoMapper(assemblies);
        }
    }
}
