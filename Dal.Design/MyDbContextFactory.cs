using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Dal.Design;

public class MyDbContextFactory : IDesignTimeDbContextFactory<MyDbContext>
{
    public MyDbContext CreateDbContext(string[] args)
    {
        // Use a local SQL Server instance or a placeholder connection string for design-time
        var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AspireDevDb;Trusted_Connection=True;MultipleActiveResultSets=true"
            ,b => b.MigrationsAssembly("Dal.Design"));
        return new MyDbContext(optionsBuilder.Options);
    }
}