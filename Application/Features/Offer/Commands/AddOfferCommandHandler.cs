using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Response;
using Application.Interfaces.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Application.Features.Offer.Commands
{
    public class AddOfferCommandHandler : IRequestHandler<AddOfferCommand, Response<long>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddOfferCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<long>> Handle(AddOfferCommand request, CancellationToken cancellationToken)
        {
            var offer= _mapper.Map<Domain.Entities.Offer>(request);

            offer.DateCreate = DateTime.UtcNow;

            await _unitOfWork.OfferRepository.AddAsync(offer,cancellationToken);
            var result = await _unitOfWork.SaveAsync();

            if (result == 0)
            {
                return Response<long>.Fail("could not add offer");
            }

            return Response<long>.Success(offer.Id, "offer added successfully");
        }
    }
}
