using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Response;
using Application.Dtos.Brand;
using MediatR;

namespace Application.Features.Brand.Queries.GetList
{
    public class GetBrandListQuery : IRequest<Response<List<BrandListDto>>>
    {

    }
}
