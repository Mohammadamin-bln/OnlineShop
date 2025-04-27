using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.ProductRating;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories.ProductRating
{
    public class ProductRatingRepository : BaseRepository<Domain.Entities.ProductRating, long>, IProductRatingRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRatingRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
