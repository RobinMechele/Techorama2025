using Domain;
using System.Net.Http.Json;
using Techorama2025.Products.Requests;

namespace Techorama2025.IntegrationTests;

/// <summary>
/// These tests make use of the fixture, which sets up a singular database instance and a client to interact with the API.
/// Side-note, Nswag would be better to use, so that you don't have to write the API calls yourself.
/// But i'm lazy and don't want to set it up right now.
/// </summary>
public class ProductTests(DatabaseFixture fixture) : IClassFixture<DatabaseFixture>
{
    [Fact]
    public async Task CreateProduct()
    {
        // Arrange
        Product expectedProduct = new()
        {
            Name = "Test Product",
            Description = "This is a test product.",
            Price = 9.99m
        };

        CreateProductRequest request = new()
        {
            Name = expectedProduct.Name,
            Description = expectedProduct.Description,
            Price = expectedProduct.Price
        };

        // Act
        var response = await fixture.Client.PostAsJsonAsync("/Product", request, TestContext.Current.CancellationToken);

        // Assert
        response.EnsureSuccessStatusCode();
        var id = await response.Content.ReadFromJsonAsync<int>(cancellationToken: TestContext.Current.CancellationToken);
        var product = await fixture.Client.GetFromJsonAsync<Product>($"/Product?id={id}", TestContext.Current.CancellationToken);

        Assert.Equal(expectedProduct.Name, product?.Name);
        Assert.Equal(expectedProduct.Description, product?.Description);
        Assert.Equal(expectedProduct.Price, product?.Price);
    }

    [Fact]
    public async Task UpdateProduct()
    {
        // Arrange
        CreateProductRequest request = new()
        {
            Name = "Some product",
            Description = "Some product with a lame description",
            Price = 9.99m
        };
        var response = await fixture.Client.PostAsJsonAsync("/Product", request, TestContext.Current.CancellationToken);
        var id = await response.Content.ReadFromJsonAsync<int>(cancellationToken: TestContext.Current.CancellationToken);
        Product expectedProduct = new()
        {
            Id = id,
            Name = "Awesome Product",
            Description = "This product is pretty awesome",
            Price = 99.99m
        };

        // Act
        await fixture.Client.PutAsJsonAsync("/Product", new UpdateProductRequest
        {
            Id = id,
            Name = expectedProduct.Name,
            Description = expectedProduct.Description,
            Price = expectedProduct.Price
        }, TestContext.Current.CancellationToken);

        // Assert
        var product = await fixture.Client.GetFromJsonAsync<Product>($"/Product?id={id}", TestContext.Current.CancellationToken);
        Assert.Equal(expectedProduct.Name, product?.Name);
        Assert.Equal(expectedProduct.Description, product?.Description);
        Assert.Equal(expectedProduct.Price, product?.Price);
    }

    [Fact]
    public async Task DeleteProduct()
    {
        // Arrange
        Product product = new()
        {
            Name = "Product to delete",
            Description = "This product will be deleted.",
            Price = 19.99m
        };
        // -> First save the product to get an ID.
        CreateProductRequest request = new()
        {
            Name = product.Name,
            Description = product.Description,
            Price = product.Price
        };
        var saveResponse = await fixture.Client.PostAsJsonAsync("/Product", request, TestContext.Current.CancellationToken);
        var id = await saveResponse.Content.ReadFromJsonAsync<int>(cancellationToken: TestContext.Current.CancellationToken);

        // Act
        var deleteResponse = await fixture.Client.DeleteAsync($"/Product?id={id}", TestContext.Current.CancellationToken);

        // Assert
        deleteResponse.EnsureSuccessStatusCode();
        // Verify that the product is deleted.
        var getResponse = await fixture.Client.GetAsync($"/Product?id={id}", TestContext.Current.CancellationToken);
        Assert.Equal(System.Net.HttpStatusCode.NotFound, getResponse.StatusCode);
    }

    #region Increase test count - to visualise the speed in the Test Explorer

    private async Task dummyCreateMethod()
    {
        // Arrange
        Product expectedProduct = new()
        {
            Name = "Test Product",
            Description = "This is a test product.",
            Price = 9.99m
        };

        CreateProductRequest request = new()
        {
            Name = expectedProduct.Name,
            Description = expectedProduct.Description,
            Price = expectedProduct.Price
        };

        // Act
        var response = await fixture.Client.PostAsJsonAsync("/Product", request, TestContext.Current.CancellationToken);

        // Assert
        response.EnsureSuccessStatusCode();
        var id = await response.Content.ReadFromJsonAsync<int>(cancellationToken: TestContext.Current.CancellationToken);
        var product = await fixture.Client.GetFromJsonAsync<Product>($"/Product?id={id}", TestContext.Current.CancellationToken);

        Assert.Equal(expectedProduct.Name, product?.Name);
        Assert.Equal(expectedProduct.Description, product?.Description);
        Assert.Equal(expectedProduct.Price, product?.Price);
    }

    [Fact]
    public async Task CreateProduct_v2()
    {
        await dummyCreateMethod();
    }

    [Fact]
    public async Task CreateProduct_v3()
    {
        await dummyCreateMethod();
    }

    [Fact]
    public async Task CreateProduct_v4()
    {
        await dummyCreateMethod();
    }

    [Fact]
    public async Task CreateProduct_v5()
    {
        await dummyCreateMethod();
    }

    [Fact]
    public async Task CreateProduct_v6()
    {
        await dummyCreateMethod();
    }

    [Fact]
    public async Task CreateProduct_v7()
    {
        await dummyCreateMethod();
    }

    [Fact]
    public async Task CreateProduct_v8()
    {
        await dummyCreateMethod();
    }

    [Fact]
    public async Task CreateProduct_v9()
    {
        await dummyCreateMethod();
    }

    [Fact]
    public async Task CreateProduct_v10()
    {
        await dummyCreateMethod();
    }

    [Fact]
    public async Task CreateProduct_v11()
    {
        await dummyCreateMethod();
    }

    [Fact]
    public async Task CreateProduct_v12()
    {
        await dummyCreateMethod();
    }

    [Fact]
    public async Task CreateProduct_v13()
    {
        await dummyCreateMethod();
    }

    [Fact]
    public async Task CreateProduct_v14()
    {
        await dummyCreateMethod();
    }

    [Fact]
    public async Task CreateProduct_v15()
    {
        await dummyCreateMethod();
    }

    [Fact]
    public async Task CreateProduct_v16()
    {
        await dummyCreateMethod();
    }

    [Fact]
    public async Task CreateProduct_v17()
    {
        await dummyCreateMethod();
    }
    #endregion
}
