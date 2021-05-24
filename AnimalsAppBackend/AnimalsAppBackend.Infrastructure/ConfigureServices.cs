using AnimalsAppBackend.ApplicationSerices;
using AnimalsAppBackend.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace AnimalsAppBackend.Infrastructure
{
    public static class ConfigureServices
    {
        public static void ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<IUsersManagementService, UsersManagementService>();

            //Turning off automatic validation attributes handling because now we will handle those manually with
            //ValidateModelAttribute to return our custom error message json data
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
        }
    }
}
