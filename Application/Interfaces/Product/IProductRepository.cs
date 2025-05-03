using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.BaseRepository;

namespace Application.Interfaces.Product
{
    public interface IProductRepository : IRepository<Domain.Entities.Product, long>
    {
        public  Task<Domain.Entities.Product?> GetByIdWithIncludesAsync(long id);

        public Task<Domain.Entities.Offer> GetActiveOfferAsync(long productId);

        public Task<Domain.Entities.Offer> GetActiveOfferForProductListAsync(long productId);
    }
}
