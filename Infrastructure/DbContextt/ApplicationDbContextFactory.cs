using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.DbContextt
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            // Configure the connection string manually for design-time operations
            optionsBuilder.UseMySql("Server=localhost;Database=ecommerce;User=root;Password=Forgotpassword11;", 
                new MySqlServerVersion(new Version(8, 0, 2)));

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
