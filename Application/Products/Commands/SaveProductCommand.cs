using MediatR;

namespace Application.Products.Commands;

public record SaveProductCommand(string Name, string Description, decimal Price) : IRequest;
