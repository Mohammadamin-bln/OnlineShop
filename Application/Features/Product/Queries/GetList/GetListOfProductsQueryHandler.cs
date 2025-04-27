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
using Microsoft.IdentityModel.Tokens;

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
            var productsQuery = _unitOfWork.ProductRepository.GetQueryable();

            productsQuery = productsQuery.Include(x => x.ProductColor)
                .Include(x => x.Brand);

            //.ProjectTo<ProductListDto>(_mapper.ConfigurationProvider);

            if (request.BrandId.HasValue)
            {
                productsQuery = productsQuery.Where(x => x.BrandId == request.BrandId);
            }

            if (request.MinPrice.HasValue && request.MaxPrice.HasValue)
            {
                productsQuery = productsQuery.Where(x => x.Price >= request.MinPrice && x.Price <= request.MaxPrice);
            }
            if (!request.NameSearch.IsNullOrEmpty())
            {
                productsQuery = productsQuery.Where(x => x.Name.Contains(request.NameSearch));
            }
            if (request.InStockOnly is true)
            {
                productsQuery = productsQuery.Where(x => x.Stock > 0);
            }

            if (request.Size.HasValue)
            {
                productsQuery = productsQuery.Where(x => x.Size == request.Size.Value);
            }
            if (request.ColorId.HasValue)
            {
                productsQuery = productsQuery.Where(x => x.ColorId == request.ColorId);
            }

            if (!request.SortOrder.IsNullOrEmpty())
            {
                productsQuery = request.SortOrder switch
                {
                    "price_asc" => productsQuery.OrderBy(x => x.Price),
                    "price_desc" => productsQuery.OrderByDescending(x => x.Price),
                    "newest" => productsQuery.OrderByDescending(x => x.DateCreate),
                    _ => productsQuery.OrderBy(x => x.Name)
                };
            }
            else
            {
                productsQuery = productsQuery.OrderBy(x => x.Name);
            }



            var paginatedList = await PaginatedList<ProductListDto>.CreateAsync(productsQuery.ProjectTo<ProductListDto>(_mapper.ConfigurationProvider), request.PageIndex, request.PageSize);

            if (!paginatedList.Items.Any())
            {
                throw new NotFoundException("no products found");
            }

            return new PaginatedResponse<ProductListDto>(paginatedList);



        }
    }
}
