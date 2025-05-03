using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Offer;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Offer
{
    internal class OfferRepository : BaseRepository<Domain.Entities.Offer, long>, IOfferRepository
    {
        private readonly ApplicationDbContext _context;
        public OfferRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Domain.Entities.Offer>> GetExpiredOffersAsync()
        {
            return await _context.Offers.Where(x => x.EndDate <= DateTime.UtcNow)
                .ToListAsync();
        }
    }
}
