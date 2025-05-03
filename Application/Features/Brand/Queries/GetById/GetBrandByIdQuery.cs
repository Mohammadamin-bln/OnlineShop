using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Response;
using Application.Dtos.Brand;
using MediatR;

namespace Application.Features.Brand.Queries.GetById
{
    public class GetBrandByIdQuery : IRequest<Response<BrandListDto>>
    {
        public long Id { get; set; }
    }
}
