using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Response;
using Application.Dtos.Brand;
using Application.Dtos.ProductColor;
using Application.Exceptions;
using Application.Interfaces.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Application.Features.ProductColor.Queries.GetById
{
    public class GetProductColorByIdQueryHandler : IRequestHandler<GetProductColorByIdQuery, Response<ProductColorListDto>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProductColorByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<ProductColorListDto>> Handle(GetProductColorByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.ProductColorRepository.GetByIdAsync(request.Id);
            if (entity == null)
            {
                throw new NotFoundException("could not find the Color");
            }

            var result = _mapper.Map<ProductColorListDto>(entity);

            return Response<ProductColorListDto>.Success(result);
        }
    }
}
