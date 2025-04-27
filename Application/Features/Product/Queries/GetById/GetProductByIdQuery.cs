using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Response;
using Application.Dtos.Product;
using MediatR;

namespace Application.Features.Product.Queries.GetById
{
    public class GetProductByIdQuery : IRequest<Response<ProductDetailsDto>>
    {
        public long Id { get; set; }
    }
}
