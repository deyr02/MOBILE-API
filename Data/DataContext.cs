using Microsoft.EntityFrameworkCore;
using mobile_api.Model;

namespace mobile_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> products {get; set;}
        public DbSet<ProductCategory> ProductCategories {get; set;}
        
         protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<Product>()
              .HasOne(P=> P.ProductCategory)
              .WithMany(b=> b.Products);
                

        }
    }
}