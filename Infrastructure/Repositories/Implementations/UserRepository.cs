using Domain.Entities;
using Infrastructure.DbContextt;
using Infrastructure.Repositories.Interfaces;

namespace Infrastructure.Repositories.Implementations
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}