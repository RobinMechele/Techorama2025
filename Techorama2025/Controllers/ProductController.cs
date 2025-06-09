using Application.Products.Models;
using Microsoft.AspNetCore.Mvc;

namespace Techorama2025.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    [HttpGet(Name = "GetProduct")]
    public IEnumerable<ProductModel> Get()
    {
        // TODO: go to the application layer!
        return [.. Enumerable.Range(1, 5).Select(index => new ProductModel
        {
            Id = index,
            Name = $"Product {index}",
            Description = $"Description for Product {index}",
            Price = Random.Shared.Next(10, 100)

        })];
    }
}
