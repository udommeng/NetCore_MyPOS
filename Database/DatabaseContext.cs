using Microsoft.EntityFrameworkCore;
using MyPOS.Models;

namespace MyPOS.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductSize> ProductSize { get; set; }

        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductSize>().ToTable("Product_Size");

            // Naming convention snake case
            modelBuilder.Entity<Product>(b =>
            {
                b.Property(u => u.ProductID).HasColumnName("Product_ID");
                b.Property(u => u.CategoryID).HasColumnName("Category_ID");
                b.Property(u => u.CodeName).HasColumnName("Code_Name");

            });

            modelBuilder.Entity<Category>(b =>
            {
                b.Property(u => u.CategoryID).HasColumnName("Category_ID");
            });

            modelBuilder.Entity<ProductSize>(b =>
            {
                b.Property(u => u.ProductID).HasColumnName("Product_ID");
            });

            // Default Value
            modelBuilder.Entity<Product>(b =>
            {
                b.Property(p => p.Timestamp).HasDefaultValueSql("getdate()");
                b.Property(p => p.Name).HasDefaultValue("unknows");
            });

            // Data Types
            modelBuilder.Entity<Product>(b =>
            {
                b.Property(p => p.Name).HasColumnType("varchar(200)");
            });

            // Required
            modelBuilder.Entity<Product>().Property(p => p.CodeName).IsRequired();
        }
    }
}