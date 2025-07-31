using Microsoft.EntityFrameworkCore;

namespace Dal.UnitTests;

// This class is a fast read-only test class that uses a fixture to share the same database container across all tests.
// This avoids the overhead of starting and stopping the container for each test, making the tests run much faster.
public class FastReadOnlyTests(DatabaseFixture fixture) : IClassFixture<DatabaseFixture>
{
    [Fact]
    public async Task Count1()
    {
        await using MyDbContext context = fixture.CreateContext();
        Assert.Equal(0, await context.Products.CountAsync(TestContext.Current.CancellationToken));
    }

    [Fact]
    public async Task Count2()
    {
        await using MyDbContext context = fixture.CreateContext();
        Assert.Equal(0, await context.Products.CountAsync(TestContext.Current.CancellationToken));
    }

    [Fact]
    public async Task Count3()
    {
        await using MyDbContext context = fixture.CreateContext();
        Assert.Equal(0, await context.Products.CountAsync(TestContext.Current.CancellationToken));
    }
}