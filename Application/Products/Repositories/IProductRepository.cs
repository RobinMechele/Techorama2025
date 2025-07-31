using Domain;

namespace Application.Products.Repositories;

public interface IProductRepository
{
    Task<Product?> GetProductByIdAsync(int productId, CancellationToken cancellationToken = default);
    Task<int> SaveAsync(Product product, CancellationToken cancellationToken = default);
    Task DeleteAsync(int productId, CancellationToken cancellationToken = default);
    Task<int> CountAsync(CancellationToken cancellationToken = default);
}
