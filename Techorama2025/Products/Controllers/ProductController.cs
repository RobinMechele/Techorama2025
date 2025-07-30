using Application.Products.Commands;
using Application.Products.Models;
using Application.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Techorama2025.Products.Requests;

namespace Techorama2025.Products.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ProductModel> GetProductById(int id)
    {
        try
        {
            return await mediator.Send(new GetProductByIdQuery(id));
        }
        catch (KeyNotFoundException)
        {
            // If the product is not found, return a 404 Not Found response.
            Response.StatusCode = 404;
            return null!;
        }
        catch (Exception)
        {
            throw;
        }
    }
    
    [HttpPost]
    public async Task<int> CreateProduct([FromBody] CreateProductRequest request)
    {
        var command = new CreateProductCommand(request.Name, request.Description, request.Price);
        var id = await mediator.Send(command);
        return id;
    }

    [HttpPut]
    public async Task UpdateProduct([FromBody] UpdateProductRequest request)
    {
        var command = new UpdateProductCommand(request.Id, request.Name, request.Description, request.Price);
        await mediator.Send(command);
    }

    [HttpDelete]
    public async Task DeleteProduct(int id)
    {
        var command = new DeleteProductCommand(id);
        await mediator.Send(command);
    }
}
