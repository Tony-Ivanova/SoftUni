namespace P03_SalesDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using P03_SalesDatabase.Data.Models;

    public class SalesContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Store> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer
                    (Configuration.ConfigurationString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity
                .HasKey(p => p.ProductId);

                entity
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired(true)
                .IsUnicode(true);

                entity
                .Property(p => p.Description)
                .HasMaxLength(250)
                .HasDefaultValue("No description");

                entity
                .HasMany(s => s.Sales)
                .WithOne(p => p.Product)
                .HasForeignKey(p => p.ProductId);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity
                .HasKey(c => c.CustomerId);

                entity
                .Property(c => c.Name)
                .HasMaxLength(100)
                .IsUnicode(true)
                .IsRequired(true);

                entity
                .Property(c => c.Email)
                .HasMaxLength(80);

                entity
                .Property(c => c.CreditCardNumber)
                .IsRequired(true)
                .IsUnicode(true);

                entity
                .HasMany(s => s.Sales)
                .WithOne(c => c.Customer)
                .HasForeignKey(c => c.CustomerId);
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity
                .HasKey(s => s.StoreId);

                entity
                .Property(s => s.Name)
                .HasMaxLength(80)
                .IsRequired(true)
                .IsUnicode(true);

                entity
                .HasMany(sa => sa.Sales)
                .WithOne(s => s.Store)
                .HasForeignKey(s => s.StoreId);
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(sa => sa.SaleId);

                entity.Property(sa => sa.Date)
                .HasDefaultValueSql("GetDate()");
            });
        }
    }
}
