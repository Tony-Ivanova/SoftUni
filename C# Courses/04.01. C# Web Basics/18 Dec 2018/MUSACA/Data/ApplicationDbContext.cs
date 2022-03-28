namespace MUSACA.Data
{
    using Microsoft.EntityFrameworkCore;
    using MUSACA.Models;

    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Receipt> Receipts { get; set; }

        public DbSet<OrderProduct> OrderProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
        }
               
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OrderProduct>().HasKey(x => new { x.OrderId, x.ProductId });
        }
    }
}
