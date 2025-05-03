using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Response;
using Application.Dtos.Brand;
using Application.Dtos.Category;
using Application.Exceptions;
using Application.Interfaces.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Queries.GetById
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Response<CategoryListDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCategoryByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<CategoryListDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.CategoryRepository.GetByIdAsync(request.Id);
            if (entity == null)
            {
                throw new NotFoundException("could not find the Category");
            }

            var result = _mapper.Map<CategoryListDto>(entity);

            return Response<CategoryListDto>.Success(result);
        }
    }
}
