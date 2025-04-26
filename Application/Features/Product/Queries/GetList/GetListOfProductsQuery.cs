using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common;
using Application.Common.PaginatedResponse;
using Application.Dtos.Product;
using MediatR;

namespace Application.Features.Product.Queries.GetPaginated
{
    public class GetListOfProductsQuery : PaginatedRequest,IRequest<PaginatedResponse<ProductListDto>>
    {
    }
}
