using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Response;
using MediatR;

namespace Application.Features.Brand.Commands.Add
{
    public class AddBrandCommand : IRequest<Response<bool>>
    {
        public string Name { get; set; }
    }
}
