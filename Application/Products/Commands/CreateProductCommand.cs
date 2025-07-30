using MediatR;

namespace Application.Products.Commands;

public record CreateProductCommand(string Name, string Description, decimal Price) : IRequest<int>;
