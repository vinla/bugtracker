using Bugtracker.Core;
using Bugtracker.MongoStore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddMongoBugStore(this IServiceCollection services, string connectionString, string databaseName)
        {
            services.Configure<MongoOptions>(opts => {
                opts.ConnectionString = connectionString;
                opts.DatabaseName = databaseName;
            });
            
            services.AddScoped<IDataStore<Bug>, BugStore>();
            services.AddScoped<IDataStore<User>, UserStore>();
            return services;
        }
    }
}