using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Response;
using Application.Dtos.ProductColor;
using Application.Exceptions;
using Application.Interfaces.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Application.Features.ProductColor.Queries.GetList
{
    public class GetProductColorListQueryHandler : IRequestHandler<GetProductColorListQuery, Response<List<ProductColorListDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProductColorListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<List<ProductColorListDto>>> Handle(GetProductColorListQuery request, CancellationToken cancellationToken)
        {
            var productColors = await _unitOfWork.ProductColorRepository.GetList(cancellationToken);

            if (productColors == null)
            {
                throw new NotFoundException("could not find any product color ");
            }

            var result = _mapper.Map<List<ProductColorListDto>>(productColors);

            return Response<List<ProductColorListDto>>.Success(result);
        }
    }
}
