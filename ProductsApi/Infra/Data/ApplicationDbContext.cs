using Microsoft.EntityFrameworkCore;
using ProductsApi.Entities;

namespace ProductsApi.Infra.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ApplicationDbContext(DbContextOptions options): base(options)
        {
        }
    }
}
