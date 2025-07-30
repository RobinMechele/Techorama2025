using Application.Products.Repositories;
using Domain;
using MediatR;

namespace Application.Products.Commands.Handlers;

internal sealed class CreateProductCommandHandler(IProductRepository productRepository) : IRequestHandler<CreateProductCommand, int>
{
    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Id = null, // This will be set by the repository after saving.
            Name = request.Name,
            Description = request.Description,
            Price = request.Price
        };

        return await productRepository.SaveAsync(product, cancellationToken);
    }
}
