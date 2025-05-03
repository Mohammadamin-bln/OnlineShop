using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.OfferService;
using Application.Interfaces.UnitOfWork;

namespace Infrastructure.Services
{
    public class OfferService : IOfferService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OfferService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task DeactivateExpiredOffers()
        {
            var expiredOffers = await _unitOfWork.OfferRepository.GetExpiredOffersAsync();

            foreach (var offer in expiredOffers)
            {
                offer.IsDeleted = true;
            }
            await _unitOfWork.SaveAsync();
        }
    }
}
