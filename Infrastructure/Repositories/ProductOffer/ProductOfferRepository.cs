using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.ProductOffer;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.ProductOffer
{
    public class ProductOfferRepository : BaseRepository<Domain.Entities.ProductOffer, long>, IProductOfferRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductOfferRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


    }
}
