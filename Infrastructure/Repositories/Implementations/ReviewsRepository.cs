using Domain.Entities;
using Infrastructure.DbContextt;
using Infrastructure.Repositories.Interfaces;

namespace Infrastructure.Repositories.Implementations
{
    public class ReviewsRepository : GenericRepository<Review>, IReviewsRepository
    {
        public ReviewsRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}