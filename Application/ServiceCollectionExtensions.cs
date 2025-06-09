using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var xistingAssembly = typeof(ServiceCollectionExtensions).Assembly;

        // Register MediatR for handling commands and queries
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(xistingAssembly));

        // Register other application services, repositories, etc.


        return services;
    }
}
