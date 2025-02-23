using Domain.Entities;
using Infrastructure.DbContextt;
using Infrastructure.Repositories.Interfaces;


namespace Infrastructure.Repositories.Implementations
{
    public class CartItemsRepository : GenericRepository<CartItem>, ICartItemsRepository
    {
        public CartItemsRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}