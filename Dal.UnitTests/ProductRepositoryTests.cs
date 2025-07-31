using Dal.Products;

namespace Dal.UnitTests;

/// <summary>
/// In all other examples, we use the DbContext directly. But in a real application, a repository pattern could be used to make everything 
/// data related into a singular space.
/// 
/// Yes, the examples given in the previous tests also work here perfectly fine. And it shows that the repository pattern is quite handy for those things.
/// </summary>
public class ProductRepositoryTests(DatabaseFixture fixture) : IClassFixture<DatabaseFixture>
{
    [Fact]
    public async Task Count1()
    {
        await using MyDbContext context = fixture.CreateContext();
        var repository = new ProductRepository(context);

        var result = await repository.CountAsync(TestContext.Current.CancellationToken);

        Assert.Equal(0, result);
    }

    [Fact]
    public async Task Count2()
    {
        await using MyDbContext context = fixture.CreateContext();
        var repository = new ProductRepository(context);

        var result = await repository.CountAsync(TestContext.Current.CancellationToken);

        Assert.Equal(0, result);
    }

    [Fact]
    public async Task Count3()
    {
        await using MyDbContext context = fixture.CreateContext();
        var repository = new ProductRepository(context);

        var result = await repository.CountAsync(TestContext.Current.CancellationToken);

        Assert.Equal(0, result);
    }

    [Fact]
    public async Task Add_and_Count()
    {
        await using var context = fixture.CreateContext();

        // Start a transaction that will be rolled back at the end of the test
        _ = await context.Database.BeginTransactionAsync(TestContext.Current.CancellationToken);

        var repository = new ProductRepository(context);
        await repository.SaveAsync(new() { Name = "Test", Description = "Test product description", Price = 42 }, TestContext.Current.CancellationToken);

        // Act
        var result = await repository.CountAsync(TestContext.Current.CancellationToken);

        Assert.Equal(1, result);

        // Now the transaction is rolled back automatically when the test ends,
        // because we didn't commit it and when our context is disposed, the results are lost (which we want for isolation!).
    }

    [Fact]
    public async Task Add_and_Count_v2()
    {
        await using var context = fixture.CreateContext();

        // Start a transaction that will be rolled back at the end of the test
        _ = await context.Database.BeginTransactionAsync(TestContext.Current.CancellationToken);

        var repository = new ProductRepository(context);
        await repository.SaveAsync(new() { Name = "Test", Description = "Test product description", Price = 42 }, TestContext.Current.CancellationToken);

        // Act
        var result = await repository.CountAsync(TestContext.Current.CancellationToken);

        Assert.Equal(1, result);

        // Now the transaction is rolled back automatically when the test ends,
        // because we didn't commit it and when our context is disposed, the results are lost (which we want for isolation!).
    }

    [Fact]
    public async Task Add_and_Count_v3()
    {
        await using var context = fixture.CreateContext();

        // Start a transaction that will be rolled back at the end of the test
        _ = await context.Database.BeginTransactionAsync(TestContext.Current.CancellationToken);

        var repository = new ProductRepository(context);
        await repository.SaveAsync(new() { Name = "Test", Description = "Test product description", Price = 42 }, TestContext.Current.CancellationToken);

        // Act
        var result = await repository.CountAsync(TestContext.Current.CancellationToken);

        Assert.Equal(1, result);

        // Now the transaction is rolled back automatically when the test ends,
        // because we didn't commit it and when our context is disposed, the results are lost (which we want for isolation!).
    }

}
