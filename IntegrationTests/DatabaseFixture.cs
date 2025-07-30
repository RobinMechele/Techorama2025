using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Testcontainers.MsSql;

namespace Techorama2025.IntegrationTests;

public sealed class DatabaseFixture : IAsyncLifetime
{
    private MsSqlContainer _dbContainer = null!;

    internal HttpClient Client { get; private set; } = null!;

    public async ValueTask InitializeAsync()
    {
        _dbContainer = new MsSqlBuilder().Build();
        await _dbContainer.StartAsync();

        var factory = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.ConfigureAppConfiguration((context, config) => {
                    // Override the connection string to use the test database
                    var settings = new Dictionary<string, string?>
                    {
                        ["ConnectionStrings:DefaultConnection"] = _dbContainer.GetConnectionString()
                    };
                    config.AddInMemoryCollection(settings);
                });
            });

        Client = factory.CreateClient();
    }

    public async ValueTask DisposeAsync()
    {
        Client.Dispose();
        await _dbContainer.DisposeAsync();
    }
}