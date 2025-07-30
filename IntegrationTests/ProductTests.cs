using Domain;
using System.Net.Http.Json;

namespace Techorama2025.IntegrationTests;

/// <summary>
/// These tests make use of the fixture, which sets up a singular database instance and a client to interact with the API.
/// Side-note, Nswag would be better to use, so that you don't have to write the API calls yourself.
/// But i'm lazy and don't want to set it up right now.
/// </summary>
public class ProductTests(DatabaseFixture fixture) : IClassFixture<DatabaseFixture>
{
    [Fact]
    public async Task SaveSingleProduct()
    {
        // Arrange
        Product someProduct = new()
        {
            Name = "Test Product",
            Description = "This is a test product.",
            Price = 9.99m
        };

        // Act
        var response = await fixture.Client.PostAsJsonAsync("/Product", someProduct, TestContext.Current.CancellationToken);
        //var getResponse = await fixture.Client.GetFromJsonAsync<Product>($"/Product?id={1}", TestContext.Current.CancellationToken);

        // Assert
        response.EnsureSuccessStatusCode();
    }
}
