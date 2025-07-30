using MediatR;

namespace Application.Products.Commands;

public record DeleteProductCommand(int ProductId) : IRequest;
