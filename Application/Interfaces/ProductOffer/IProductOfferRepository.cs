using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.BaseRepository;

namespace Application.Interfaces.ProductOffer
{
    public interface IProductOfferRepository : IRepository<Domain.Entities.ProductOffer,long>
    {

    }
}
