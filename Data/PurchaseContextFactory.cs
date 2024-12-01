using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HelloBlazorApp.Data
{
    public class PurchaseContextFactory : IDesignTimeDbContextFactory<PurchaseContext>
    {
        public PurchaseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PurchaseContext>();
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;UserId=postgres;Database=Blazor;Password=123456;");
            return new PurchaseContext(optionsBuilder.Options);
        }
    }
}