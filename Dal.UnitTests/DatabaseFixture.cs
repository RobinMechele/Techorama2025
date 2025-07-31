using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Testcontainers.MsSql;

namespace Dal.UnitTests;
public sealed class DatabaseFixture : IAsyncLifetime
{
    private MsSqlContainer _dbContainer = null!;
    private IDbContextFactory<MyDbContext> _dbContextFactory = null!;

    public async ValueTask DisposeAsync() => await _dbContainer.DisposeAsync().AsTask();

    public async ValueTask InitializeAsync()
    {
        _dbContainer = new MsSqlBuilder().Build();
        await _dbContainer.StartAsync();

        var options = new DbContextOptionsBuilder<MyDbContext>()
            .UseSqlServer(_dbContainer.GetConnectionString())
            .Options;
        _dbContextFactory = new PooledDbContextFactory<MyDbContext>(options);

        using var context = _dbContextFactory.CreateDbContext();
        await context.Database.EnsureCreatedAsync(TestContext.Current.CancellationToken);

        // Seed some initial data here?
    }

    public MyDbContext CreateContext() => _dbContextFactory.CreateDbContext();
}
