using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Paginated;
using Application.Common.PaginatedResponse;
using Application.Dtos.Product;
using Application.Exceptions;
using Application.Interfaces.UnitOfWork;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Product.Queries.GetPaginated
{
    public class GetListOfProductsQueryHandler : IRequestHandler<GetListOfProductsQuery, PaginatedResponse<ProductListDto>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetListOfProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PaginatedResponse<ProductListDto>> Handle(GetListOfProductsQuery request, CancellationToken cancellationToken)
        {
            var productsQuery = _unitOfWork.ProductRepository.GetQueryable()
                .Include(x => x.ProductColor)
                .Include(x => x.Brand)
                .ProjectTo<ProductListDto>(_mapper.ConfigurationProvider);



            var paginatedList= await PaginatedList<ProductListDto>.CreateAsync(productsQuery,request.PageIndex,request.PageSize);

            if (!paginatedList.Items.Any())
            {
                throw new NotFoundException("no products found");
            }

            return new PaginatedResponse<ProductListDto>(paginatedList);


            
        }
    }
}
