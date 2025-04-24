using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Product;
using Application.Interfaces.ProductColor;
using Infrastructure.Contexts;
using MediatR;

namespace Infrastructure.Repositories.ProductColor
{
    public class ProductColorRepository : BaseRepository<Domain.Entities.ProductColor, long>, IProductColorRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductColorRepository(ApplicationDbContext context) : base(context)
        {
            _context= context;
        }
    }
}
