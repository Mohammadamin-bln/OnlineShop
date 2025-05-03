using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Product;
using Application.Interfaces.User;
using Domain.Entities;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Product
{
    public class ProductRepository : BaseRepository<Domain.Entities.Product, long>, IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Product?> GetByIdWithIncludesAsync(long id)
        {
            return await _context.Products
                .Include(p => p.ProductRatings)
                .Include(p=>p.ProductColor)
                .Include(p=>p.Brand)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Domain.Entities.Offer> GetActiveOfferAsync(long productId)
        {
            return await _context.ProductOffers
                .Where(po => po.ProductId == productId && !po.Offer.IsDeleted)
                .Select(po => po.Offer)
                .FirstOrDefaultAsync();
        }
        public async Task<Domain.Entities.Offer> GetActiveOfferForProductListAsync(long productId)
        {
            var product = await _context.Products
                .Include(p => p.ProductOffers)
                .ThenInclude(po => po.Offer)
                .FirstOrDefaultAsync(p => p.Id == productId);

            if (product == null)
                return null;


            return product.ProductOffers
                .FirstOrDefault(po => !po.Offer.IsDeleted)?.Offer;
        }


    }
}
