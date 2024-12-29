using MatareseDB.Infrastructure.Repositories;

namespace MatareseDB.Api.DependencyInjection
{
    public static class InfrastructureInjection
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<CollectionRepository>();
            services.AddTransient<ObjectRepository>();
            services.AddTransient<DatabaseRepository>();
        }
    }
}
