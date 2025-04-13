using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace API.Persistence.Configuration
{
    public static partial class ServiceExtension
    {
        public static void ConfigureValidator<T>(this IServiceCollection services) where T : class
        {
            services.AddValidatorsFromAssemblyContaining<T>();
        }
    }
}
