using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AbpApp.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AbpApp.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            // Connection string is currently holding in secrets storage
            var connectionString = configuration["ConnectionString"];
            services.AddDbContext<AppDbContext>(option =>
            {
                option.UseSqlServer(connectionString);
            });

            services.AddScoped<IAppDbContext>(provider => provider
                .GetService<AppDbContext>());

            return services;
        }
    }
}
