using Application.Products.Repositories;
using MediatR;

namespace Application.Products.Commands.Handlers;

internal sealed class UpdateProductCommandHandler(IProductRepository productRepository)
    : IRequestHandler<UpdateProductCommand>
{
    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetProductByIdAsync(request.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"Product with ID {request.Id} not found.");

        // Update the product properties with the values from the request.
        product.Name = request.Name;
        product.Description = request.Description;
        product.Price = request.Price;

        // Save the updated product back to the repository.
        await productRepository.SaveAsync(product, cancellationToken);
    }
}
