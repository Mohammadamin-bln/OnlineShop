using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Response;
using Application.Dtos.Product;
using Application.Exceptions;
using Application.Interfaces.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Application.Features.Product.Queries.GetById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Response<ProductDetailsDto>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<ProductDetailsDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdWithIncludesAsync(request.Id);

            if (product == null)
            {
                throw new NotFoundException("product not found ");
            }
            var result = _mapper.Map<ProductDetailsDto>(product);

            if (product.ProductRatings != null && product.ProductRatings.Any())
            {
                result.AverageRating = product.ProductRatings.Average(a => a.Stars);
            }
            else
            {
                result.AverageRating = 0;
            }
            return Response<ProductDetailsDto>.Success(result);

        }
    }
}
