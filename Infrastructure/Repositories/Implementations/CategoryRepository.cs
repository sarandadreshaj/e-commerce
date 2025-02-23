using Domain.Entities;
using Infrastructure.DbContextt;
using Infrastructure.Repositories.Interfaces;


namespace Infrastructure.Repositories.Implementations
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}