using MatareseDB.Application.Services;

namespace MatareseDB.Api.DependencyInjection
{
    public static class ApplicationInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddTransient<CollectionService>();
            services.AddTransient<ObjectService>();
            services.AddTransient<DatabaseService>();
        }
    }
}