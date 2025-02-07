using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Domain.Entities;

namespace Infrastructure.DbContextt{
    public class ApplicationDbContext : DbContext{

        private readonly IConfiguration _configuration;
         public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
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
            .HasForeignKey(p => p.CategoryID);
            
            modelBuilder.Entity<Order>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(o => o.UserID); //order has a relationship with one user

            modelBuilder.Entity<OrderItem>()
            .HasOne<Order>()
            .WithMany()
            .HasForeignKey(oi => oi.OrderId);

            modelBuilder.Entity<OrderItem>()
            .HasOne<Product>()
            .WithMany()
            .HasForeignKey(oi => oi.ProductID);

            modelBuilder.Entity<Review>()
            .HasOne<Product>()
            .WithMany()
            .HasForeignKey(r => r.ProductID);

            modelBuilder.Entity<Review>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(r => r.UserID);

            modelBuilder.Entity<ShoppingCart>()
            .HasOne(shc => shc.User)
            .WithOne(u => u.ShoppingCart)
            .HasForeignKey<ShoppingCart>(shc => shc.UserId);

        }
    }
}