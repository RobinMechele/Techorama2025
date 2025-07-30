using Application.Products.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Dal.Products;

internal class ProductRepository(MyDbContext dbContext) : IProductRepository
{
    public Task<Product?> GetProductByIdAsync(int productId, CancellationToken cancellationToken = default)
        => dbContext.Products
            .FirstOrDefaultAsync(p => p.Id == productId, cancellationToken);

    public async Task SaveAsync(Product product, CancellationToken cancellationToken = default)
    {
        if (product.Id is null)
        {
            dbContext.Products.Add(product);
        }
        else
        {
            dbContext.Products.Update(product);
        }
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
