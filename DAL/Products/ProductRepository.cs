using Application.Products.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Dal.Products;

internal class ProductRepository(MyDbContext dbContext) : IProductRepository
{
    public Task<Product?> GetProductByIdAsync(int productId, CancellationToken cancellationToken = default)
        => dbContext.Products
            .FirstOrDefaultAsync(p => p.Id == productId, cancellationToken);
}
