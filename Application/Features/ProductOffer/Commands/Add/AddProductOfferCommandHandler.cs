using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Response;
using Application.Exceptions;
using Application.Interfaces.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Application.Features.ProductOffer.Commands.Add
{
    public class AddProductOfferCommandHandler : IRequestHandler<AddProductOfferCommand, Response<string>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddProductOfferCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddProductOfferCommand request, CancellationToken cancellationToken)
        {
            var currentDate = DateTime.UtcNow;

            var offer = await _unitOfWork.OfferRepository.GetByIdAsync(request.OfferId);

            if (offer == null)
            {
                throw new NotFoundException("offer  not found");
            }
            
            var product= await _unitOfWork.ProductRepository.GetByIdAsync(request.ProductId);
            
            if (product == null)
            {
                throw new NotFoundException("product not found");
            }
            if (offer.EndDate < currentDate)
            {
                return Response<string>.Fail("Date Of offer expired please update the offer if you want to add product  to this  offer ");
            }
            var existingProductOffer = await _unitOfWork.ProductOfferRepository
    .ExistsAsync(po => po.ProductId == request.ProductId && po.OfferId == request.OfferId);
            if (existingProductOffer)
            {
                return Response<string>.Fail("This product is already associated with the offer.");
            }

            var productOffer= _mapper.Map<Domain.Entities.ProductOffer>(request);

            productOffer.DateCreate = currentDate;

            await _unitOfWork.ProductOfferRepository.AddAsync(productOffer,cancellationToken);

            var result = await _unitOfWork.SaveAsync();

            if (result == 0)
            {
                return Response<string>.Fail("could not apply product offer");
            }
            return Response<string>.Success(string.Empty,"offer applied to product successfully");
        }
    }
}
