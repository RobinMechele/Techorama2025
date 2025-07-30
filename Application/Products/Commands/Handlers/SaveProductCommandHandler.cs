using Application.Products.Repositories;
using Domain;
using MediatR;
using System.Xml.Linq;

namespace Application.Products.Commands.Handlers;

internal class SaveProductCommandHandler(IProductRepository productRepository) : IRequestHandler<SaveProductCommand>
{
    public async Task Handle(SaveProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price
        };

        // Here you would typically save the product to a database or another storage medium.
        // For example, using a repository pattern:
        await productRepository.SaveAsync(product, cancellationToken);
    }
}
