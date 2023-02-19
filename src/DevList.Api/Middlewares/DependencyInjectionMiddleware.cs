using DevList.Domain.Interfaces;
using DevList.Domain.Models;
using DevList.Domain.Services;
using DevList.Domain.Settings;
using DevList.Infra.Context;
using DevList.Infra.Interfaces;
using DevList.Infra.Repositories;

namespace DevList.Api.Middlewares
{
    public static class DependencyInjectionMiddleware
    {
        public static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            var mongoDbSettings = configuration.GetSection("MongoDBSettings").Get<MongoDBSettings>();

            var connectionFactory = new ConnectionFactory(mongoDbSettings.ConnectionString);

            services.AddSingleton<IRepository<Developer>>(
                p => new DeveloperRepository(connectionFactory, mongoDbSettings.DatabaseName,
                    mongoDbSettings.CollectionName));

            services.AddTransient<IDeveloperService, DeveloperService>();
        }
    }
}
