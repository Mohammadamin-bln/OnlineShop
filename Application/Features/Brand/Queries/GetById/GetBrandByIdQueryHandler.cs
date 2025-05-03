using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Response;
using Application.Dtos.Brand;
using Application.Exceptions;
using Application.Interfaces.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Application.Features.Brand.Queries.GetById
{
    public class GetBrandByIdQueryHandler : IRequestHandler<GetBrandByIdQuery, Response<BrandListDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBrandByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<BrandListDto>> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
        {
            var entity= await _unitOfWork.BrandRepository.GetByIdAsync(request.Id);
            if (entity == null)
            {
                throw new NotFoundException("could not find the brand");
            }
            
            var result= _mapper.Map<BrandListDto>(entity);

            return Response<BrandListDto>.Success(result);
        }
    }
}
