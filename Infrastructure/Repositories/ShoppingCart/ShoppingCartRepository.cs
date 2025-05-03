using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.ShoppingCart;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories.ShoppingCart
{
    public class ShoppingCartRepository : BaseRepository<Domain.Entities.ShoppingCart, long>, IShoppingCartRepository
    {
        private readonly ApplicationDbContext _context;
        public ShoppingCartRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
