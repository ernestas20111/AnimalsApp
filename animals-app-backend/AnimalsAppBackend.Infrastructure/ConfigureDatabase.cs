using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AnimalsAppBackend.DataAccess;

namespace AnimalsAppBackend.Infrastructure
{
    public static class ConfigureDatabase
    {
        public static void AddDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AnimalsAppDbContext>(builder => builder.UseSqlServer(connectionString));
        }
    }
}
