using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Response;
using Application.Dtos.Category;
using MediatR;

namespace Application.Features.Category.Queries.GetById
{
    public class GetCategoryByIdQuery : IRequest<Response<CategoryListDto>>
    {
        public long Id { get; set; }
    }
}
