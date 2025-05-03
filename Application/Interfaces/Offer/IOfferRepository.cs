using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.BaseRepository;
using Domain.Entities;

namespace Application.Interfaces.Offer
{
    public interface IOfferRepository : IRepository<Domain.Entities.Offer,long>
    {
        public Task<List<Domain.Entities.Offer>> GetExpiredOffersAsync();
    }
}
