using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Brand;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories.Brand
{
    public class BrandRepository : BaseRepository<Domain.Entities.Brand, long>, IBrandRepository
    {
        private readonly ApplicationDbContext _context;
        public BrandRepository(ApplicationDbContext context) : base(context)
        {
            _context=context;
        }
    }
}
