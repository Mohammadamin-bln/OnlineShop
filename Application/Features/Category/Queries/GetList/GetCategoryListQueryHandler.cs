using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Response;
using Application.Dtos.Category;
using Application.Exceptions;
using Application.Interfaces.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Queries.GetList
{
    public class GetCategoryListQueryHandler : IRequestHandler<GetCategoryListQuery, Response<List<CategoryListDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCategoryListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<List<CategoryListDto>>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var categories = await _unitOfWork.CategoryRepository.GetList(cancellationToken);
            if (categories == null)
            {
                throw new NotFoundException("no categories found");
            }

            var result = _mapper.Map<List<CategoryListDto>>(categories);

            return Response<List<CategoryListDto>>.Success(result);
        }
    }
}
