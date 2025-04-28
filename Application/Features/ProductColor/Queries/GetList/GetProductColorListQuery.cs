using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Response;
using Application.Dtos.ProductColor;
using MediatR;

namespace Application.Features.ProductColor.Queries.GetList
{
    public class GetProductColorListQuery : IRequest<Response<List<ProductColorListDto>>>
    {
    }
}
