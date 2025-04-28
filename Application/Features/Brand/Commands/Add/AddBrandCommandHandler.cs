using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Response;
using Application.Exceptions;
using Application.Interfaces.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Application.Features.Brand.Commands.Add
{
    public class AddBrandCommandHandler : IRequestHandler<AddBrandCommand, Response<bool>>
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AddBrandCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<bool>> Handle(AddBrandCommand request, CancellationToken cancellationToken)
        {
            var checkExists = await _unitOfWork.BrandRepository.ExistsAsync(x => x.Name == request.Name);
            if (checkExists)
            {
                throw new ConflictException("This Brand already exists");
            }

            // Map the request to the brand entity
            var brandOfProduct = _mapper.Map<Domain.Entities.Brand>(request);

            // Add the brand to the repository
             await _unitOfWork.BrandRepository.AddAsync(brandOfProduct, cancellationToken);
            var result = await _unitOfWork.SaveAsync();

            // Check if the result (Id) is valid (greater than 0)
            if (result == 0)
            {
                return Response<bool>.Fail("Failed to add brand");
            }

            // Return a success response
            return Response<bool>.Success(true, "Brand added successfully");
        }
    }
}
