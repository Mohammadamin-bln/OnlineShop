using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Category;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories.Category
{
    public class CategoryRepository : BaseRepository<Domain.Entities.Category, long> , ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
