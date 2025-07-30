using Application.Products.Repositories;
using MediatR;

namespace Application.Products.Commands.Handlers;

internal sealed class DeleteProductCommandHandler(IProductRepository productRepository) : IRequestHandler<DeleteProductCommand>
{
    public Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        => productRepository.DeleteAsync(request.ProductId, cancellationToken);
}
