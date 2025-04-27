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
            return await _context.Products.Include(p => p.ProductRatings)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
