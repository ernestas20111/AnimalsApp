using AnimalsAppBackend.ApplicationSerices;
using AnimalsAppBackend.DataAccess;
using Microsoft.Extensions.DependencyInjection;

namespace AnimalsAppBackend.Infrastructure
{
    public static class ConfigureServices
    {
        public static void ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<UsersRepository>()
                .AddScoped<UsersManagementService>();
        }
    }
}
