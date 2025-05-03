using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Response;
using MediatR;

namespace Application.Features.Category.Commands.Add
{
    public class AddCategoryCommand : IRequest<Response<string>>
    {
        public string Name { get; set; }
    }
}
