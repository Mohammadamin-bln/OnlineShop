using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Response;
using MediatR;

namespace Application.Features.ProductColor.Commands.Update
{
    public class UpdateProductColorCommand  : IRequest<Response<string>>
    {
        public string Name { get; set; }
        public long Id { get; set; }
        public string? HexCode { get; set; }
    }
}
