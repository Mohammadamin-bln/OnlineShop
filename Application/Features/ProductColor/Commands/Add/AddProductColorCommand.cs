using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Response;
using MediatR;

namespace Application.Features.ProductColor.Commands.Add
{
    public class AddProductColorCommand : IRequest<Response<bool>>
    {
        public string Name { get; set; }

        public string? HexCode { get; set; }
    }
}
