using Microsoft.EntityFrameworkCore;

namespace Dal.UnitTests;

/// <summary>
/// Relational databases have isolation build in - they are named transactions.
/// They perfected it soo much, why not make use of it?
/// 
/// So, these tests make a context and open a transaction. With that context, you can do whatever you want, even in parallel, and dispose it all afterwards.
/// This is different then when doing integration tests. There, transactions are used to ensure you have the full flow of the application.
/// 
/// Solutions there are (complicated, but possible)
/// - Restoring database to original state after test.
/// - Seeding other data before each test.
/// </summary>
public class WriteTests(DatabaseFixture fixture) : IClassFixture<DatabaseFixture>
{
    [Fact]
    public async Task Add_and_Count()
    {
        await using var context = fixture.CreateContext();

        // Start a transaction that will be rolled back at the end of the test
        _ = await context.Database.BeginTransactionAsync(TestContext.Current.CancellationToken);

        context.Products.Add(new() { Name = "Test", Description = "Test product description", Price = 42 });
        await context.SaveChangesAsync(TestContext.Current.CancellationToken);

        Assert.Equal(1, await context.Products.CountAsync(TestContext.Current.CancellationToken));

        // Now the transaction is rolled back automatically when the test ends,
        // because we didn't commit it and when our context is disposed, the results are lost (which we want for isolation!).
    }

    [Fact]
    public async Task Add_and_Count_v2()
    {
        await using var context = fixture.CreateContext();

        // Start a transaction that will be rolled back at the end of the test
        _ = await context.Database.BeginTransactionAsync(TestContext.Current.CancellationToken);

        context.Products.Add(new() { Name = "Test", Description = "Test product description", Price = 42 });
        await context.SaveChangesAsync(TestContext.Current.CancellationToken);

        Assert.Equal(1, await context.Products.CountAsync(TestContext.Current.CancellationToken));

        // Now the transaction is rolled back automatically when the test ends,
        // because we didn't commit it and when our context is disposed, the results are lost (which we want for isolation!).
    }

    [Fact]
    public async Task Add_and_Count_v3()
    {
        await using var context = fixture.CreateContext();

        // Start a transaction that will be rolled back at the end of the test
        _ = await context.Database.BeginTransactionAsync(TestContext.Current.CancellationToken);

        context.Products.Add(new() { Name = "Test", Description = "Test product description", Price = 42 });
        await context.SaveChangesAsync(TestContext.Current.CancellationToken);

        Assert.Equal(1, await context.Products.CountAsync(TestContext.Current.CancellationToken));

        // Now the transaction is rolled back automatically when the test ends,
        // because we didn't commit it and when our context is disposed, the results are lost (which we want for isolation!).
    }
}
