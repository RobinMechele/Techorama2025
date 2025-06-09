using Application.Products.Repositories;
using Dal.Products;
using Microsoft.Extensions.DependencyInjection;

namespace Dal;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataProvider(this IServiceCollection services)
    {
        // Register your DbContext and repositories here
        //services.AddDbContext<MyDbContext>(options => options.UseSqlServer("YourConnectionString"));




        // Register repositories
        services.AddScoped<IProductRepository, ProductRepository>();
        return services;
    }
}
