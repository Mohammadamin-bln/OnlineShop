using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Response;
using MediatR;

namespace Application.Features.Category.Commands.Update
{
    public class UpdateCategoryCommand : IRequest<Response<string>>
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }
}
