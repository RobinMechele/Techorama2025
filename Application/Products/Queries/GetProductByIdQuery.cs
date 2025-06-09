using Application.Products.Models;
using MediatR;

namespace Application.Products.Queries;

public record GetProductByIdQuery(int Id) : IRequest<ProductModel>;
