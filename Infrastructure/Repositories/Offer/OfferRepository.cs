using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Offer;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories.Offer
{
    internal class OfferRepository : BaseRepository<Domain.Entities.Offer, long>, IOfferRepository
    {
        private readonly ApplicationDbContext _context;
        public OfferRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
