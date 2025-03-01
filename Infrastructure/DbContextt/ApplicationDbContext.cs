using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.DbContextt
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
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
                .HasOne<Category>()
                .WithMany()
                .HasForeignKey(p => p.CategoryId);
            
            modelBuilder.Entity<Order>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(o => o.UserId);

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
