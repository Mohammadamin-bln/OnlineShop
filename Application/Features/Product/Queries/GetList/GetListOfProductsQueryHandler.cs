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
                .Include(x => x.Brand)
                                .Include(x => x.ProductOffers)
                    .ThenInclude(po => po.Offer);

            //.ProjectTo<ProductListDto>(_mapper.ConfigurationProvider);by the 

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

            var paginatedProducts = await PaginatedList<Domain.Entities.Product>.CreateAsync(
            productsQuery,
            request.PageIndex,
            request.PageSize
            );


            if (!paginatedProducts.Items.Any()) 
            {
                throw new NotFoundException("No products found");
            }

            var productListDtos = paginatedProducts.Items.Select(product =>
            {
                var dto = _mapper.Map<ProductListDto>(product);

                var activeOffer = product.ProductOffers
                    .FirstOrDefault(po =>
                        !po.Offer.IsDeleted)?.Offer;
                if (activeOffer != null)
                {
                    var discountedPrice = product.Price * (1 - activeOffer.DiscountPercentage / 100);
                    dto.DiscountedPrice = discountedPrice;
                    dto.DiscountBadge = $"{activeOffer.DiscountPercentage}% OFF"; ;
                }
                return dto;
            }).ToList();

            return new PaginatedResponse<ProductListDto>(
                new PaginatedList<ProductListDto>(
                    productListDtos,
                    paginatedProducts.PageIndex,
                    paginatedProducts.PageSize,
                    paginatedProducts.TotalCount
                )
            );



        }
    }
}
