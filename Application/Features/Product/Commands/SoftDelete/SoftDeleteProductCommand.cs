using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Response;
using MediatR;

namespace Application.Features.Product.Commands.SoftDelete
{
    public class SoftDeleteProductCommand : IRequest<Response<string>>
    {
        public long Id { get; set; }
    }
}
