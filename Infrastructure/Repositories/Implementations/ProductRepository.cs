using Domain.Entities;
using Infrastructure.DbContextt;
using Infrastructure.Repositories.Interfaces;

namespace Infrastructure.Repositories.Implementations
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}