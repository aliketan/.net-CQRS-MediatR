using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace API.Persistence.Configuration
{
    using Model.Configuration;

    public static partial class ServiceExtension
    {
        public static void ConfigureDbContext(this IServiceCollection services)
        {
            services.AddScoped<IMongoDatabase>(provider =>
            {
                var settings = provider.GetRequiredService<IOptions<MongoDbSettings>>().Value;
                var client = new MongoClient(settings.ConnectionString);
                return client.GetDatabase(settings.DatabaseName);
            });
        }
    }
}
