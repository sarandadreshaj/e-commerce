using Domain.Entities;
using Infrastructure.DbContextt;
using Infrastructure.Repositories.Interfaces;

namespace Infrastructure.Repositories.Implementations
{
    public class OrderItemsRepository : GenericRepository<OrderItem>, IOrderItemsRepository
    {
        public OrderItemsRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}