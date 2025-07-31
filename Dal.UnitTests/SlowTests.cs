
using Microsoft.EntityFrameworkCore;
using Testcontainers.MsSql;

namespace Dal.UnitTests;


/// <summary>
/// These tests are a first example on how easy it is to use test containers inside your unit tests.
/// Just by adding the container and starting it, you can run your tests against a real database!
/// However - when you run these tests, you'll notice that it takes them a long time to run. Not that great, right?
/// In this example, it takes around 5-7 seconds to run each test. During the demo at Techorama, it was 700ms per test, but was using PostGresql.
/// </summary>
public sealed class SlowTests : IAsyncLifetime
{
    private readonly MsSqlContainer _dbContainer = new MsSqlBuilder().Build();

    /*
     The problem lies here: if you don't know, Xunit will initialize the container for each test inside the class.
     So if you have 3 tests, it will start the container 3 times, thus creating 3 containers to execute these tests.
    This level of isolation is super overkill - you don't need that much here at all (or in most of the cases at least).
    Consider to use Fixtures instead, which will allow you to share the same container across all tests in the class.
    -> See FastReadOnlyTests.cs for an example on how to use fixtures.
     */
    public async ValueTask InitializeAsync() => await _dbContainer.StartAsync();
    public async ValueTask DisposeAsync() => await _dbContainer.DisposeAsync().AsTask();


    [Fact]
    public async Task Count1()
    {
        var options = new DbContextOptionsBuilder<MyDbContext>()
            .UseSqlServer(_dbContainer.GetConnectionString())
            .Options;

        using var context = new MyDbContext(options);
        await context.Database.EnsureCreatedAsync(TestContext.Current.CancellationToken);

        Assert.Equal(0, await context.Products.CountAsync(TestContext.Current.CancellationToken));
    }

    [Fact]
    public async Task Count2()
    {
        var options = new DbContextOptionsBuilder<MyDbContext>()
            .UseSqlServer(_dbContainer.GetConnectionString())
            .Options;

        using var context = new MyDbContext(options);
        await context.Database.EnsureCreatedAsync(TestContext.Current.CancellationToken);

        Assert.Equal(0, await context.Products.CountAsync(TestContext.Current.CancellationToken));
    }

    [Fact]
    public async Task Count3()
    {
        var options = new DbContextOptionsBuilder<MyDbContext>()
            .UseSqlServer(_dbContainer.GetConnectionString())
            .Options;

        using var context = new MyDbContext(options);
        await context.Database.EnsureCreatedAsync(TestContext.Current.CancellationToken);

        Assert.Equal(0, await context.Products.CountAsync(TestContext.Current.CancellationToken));
    }
}
