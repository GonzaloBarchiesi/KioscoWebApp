using KioscoWebApp.Models;
using Microsoft.EntityFrameworkCore;
namespace KioscoWebApp.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options): base (options)
        {
           
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductCustomer> ProductCustomers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>()
                .HasKey(pc => new { pc.ProductId, pc.CategoryId });
            modelBuilder.Entity<ProductCategory>()
                .HasOne(p => p.Product)
                .WithMany(pc => pc.ProductCategories)
                .HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<ProductCategory>()
               .HasOne(p => p.Category)
               .WithMany(pc => pc.ProductCategories)
               .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<ProductCustomer>()
               .HasKey(pcu => new { pcu.ProductId, pcu.CustomerId });
            modelBuilder.Entity<ProductCustomer>()
                .HasOne(p => p.Product)
                .WithMany(pc => pc.ProductCustomers)
                .HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<ProductCustomer>()
               .HasOne(p => p.Customer)
               .WithMany(pcu => pcu.ProductCustomers)
               .HasForeignKey(cu => cu.CustomerId);

            modelBuilder.Entity<Category>()
                .Property(c => c.CategoryId)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Category>()
            .HasKey(p => new { p.CategoryId });

            modelBuilder.Entity<Product>()
                .Property(c => c.ProductId)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Product>()
                .HasKey(p => new { p.ProductId});
        }
    }
}
