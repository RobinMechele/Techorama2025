using Domain;

namespace Application.Products.Repositories;

public interface IProductRepository
{
    Task<Product?> GetProductByIdAsync(int productId, CancellationToken cancellationToken = default);
}
