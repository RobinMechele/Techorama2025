using Application.Products.Commands;
using Application.Products.Models;
using Application.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Techorama2025.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public Task<ProductModel> GetProductById(int id)
        => mediator.Send(new GetProductByIdQuery(id));

    [HttpPost]
    public async Task SaveProduct(string name, string description, decimal price)
    {
        // Create a command to save the product.
        var command = new SaveProductCommand(name, description, price);
        await mediator.Send(command);
    }
}
