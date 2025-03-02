using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.DbContextt
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            /* The OnConfiguring method is where you typically set up the database connection string. 
            However, if you're using Dependency Injection (DI) to provide DbContextOptions<ApplicationDbContext>, 
            you don't need to define the connection string in OnConfiguring. Instead, you should rely on the 
            configuration provided through DI. */
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)  // Explicitly reference Category
                .WithMany(c => c.Products) // Explicitly reference Products
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade); // Optional: Cascade delete products if category is deleted
            
             modelBuilder.Entity<Order>()
                .HasOne(o => o.User) // Explicitly reference User
                .WithMany(u => u.Orders) // Explicitly reference Orders
                .HasForeignKey(o => o.UserId); // Foreign key property

            modelBuilder.Entity<OrderItem>()
                .HasOne<Order>()
                .WithMany()
                .HasForeignKey(oi => oi.OrderId);

            modelBuilder.Entity<OrderItem>()
                .HasOne<Product>()
                .WithMany()
                .HasForeignKey(oi => oi.ProductId);

            modelBuilder.Entity<Review>()
                .HasOne<Product>()
                .WithMany()
                .HasForeignKey(r => r.ProductId);

            modelBuilder.Entity<Review>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<ShoppingCart>()
                .HasOne(shc => shc.User)
                .WithOne(u => u.ShoppingCart)
                .HasForeignKey<ShoppingCart>(shc => shc.UserId);
        }
    }
}
