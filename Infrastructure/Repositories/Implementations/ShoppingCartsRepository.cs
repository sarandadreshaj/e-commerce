using Domain.Entities;
using Infrastructure.DbContextt;
using Infrastructure.Repositories.Interfaces;


namespace Infrastructure.Repositories.Implementations
{
    public class ShoppingCartsRepository : GenericRepository<ShoppingCart>, IShoppingCartsRepository
    {
        public ShoppingCartsRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}