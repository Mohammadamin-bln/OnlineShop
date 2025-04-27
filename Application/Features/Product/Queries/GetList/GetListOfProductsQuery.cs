using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common;
using Application.Common.PaginatedResponse;
using Application.Dtos.Product;
using Domain.Enums;
using MediatR;

namespace Application.Features.Product.Queries.GetPaginated
{
    public class GetListOfProductsQuery : PaginatedRequest,IRequest<PaginatedResponse<ProductListDto>>
    {
        public long? BrandId { get; set; }
        public long? ColorId { get; set; }

        public decimal? MinPrice { get; set; }

        public decimal? MaxPrice { get; set; }

        public SizeOfProduct?  Size { get; set; }

        public string? SortOrder { get; set; }

        public string? NameSearch { get; set; }

        public bool? InStockOnly { get; set; }
    }
}
