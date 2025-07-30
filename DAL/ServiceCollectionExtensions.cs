using Application.Products.Repositories;
using Dal.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dal;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataProvider(this IServiceCollection services, IConfiguration configuration)
    {
        // Register your DbContext and repositories here
        services.AddDbContext<MyDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), options => 
            {
                options.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(10),
                    errorNumbersToAdd: null);
            });
        });

        // Register repositories
        services.AddScoped<IProductRepository, ProductRepository>();
        return services;
    }
}
