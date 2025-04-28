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

namespace Application.Features.Brand.Queries.GetList
{
    public class GetBrandListQueryHandler : IRequestHandler<GetBrandListQuery, Response<List<BrandListDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBrandListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<List<BrandListDto>>> Handle(GetBrandListQuery request, CancellationToken cancellationToken)
        {
            var brands = await _unitOfWork.BrandRepository.GetList(cancellationToken);
            if (brands == null)
            {
                throw new NotFoundException("no brands found");
            }

            var result = _mapper.Map<List<BrandListDto>>(brands);

            return Response<List<BrandListDto>>.Success(result);

        }
    }
}
