using Application.Products.Models;
using Application.Products.Repositories;
using MediatR;

namespace Application.Products.Queries.Handlers;

internal class GetProductByIdQueryHandler(IProductRepository productRepository) : IRequestHandler<GetProductByIdQuery, ProductModel>
{
    public async Task<ProductModel> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetProductByIdAsync(request.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"Product with ID {request.Id} not found.");

        var model = new ProductModel
        {
            Id = product.Id!.Value,
            Name = product.Name,
            Price = product.Price,
            Description = product.Description
        };

        return model;
    }
}
