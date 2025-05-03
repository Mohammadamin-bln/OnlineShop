using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Response;
using Application.Dtos.Category;
using MediatR;

namespace Application.Features.Category.Queries.GetList
{
    public class GetCategoryListQuery : IRequest<Response<List<CategoryListDto>>>
    {
    }
}
