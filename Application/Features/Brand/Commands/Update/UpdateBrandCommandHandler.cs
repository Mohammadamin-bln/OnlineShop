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

namespace Application.Features.Brand.Commands.Update
{




    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, Response<string>>
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBrandCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<string>> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = await _unitOfWork.BrandRepository.GetByIdAsync(request.Id);
            if (brand == null)
            {
                throw new NotFoundException("brand not found ");
            }

            _mapper.Map(request,brand);
            brand.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.BrandRepository.Update(brand);
            await _unitOfWork.SaveAsync();
            return Response<string>.Success(string.Empty,"brand updated successfully");
        }
    }
}
