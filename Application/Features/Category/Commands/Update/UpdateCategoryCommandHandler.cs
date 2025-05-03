using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Response;
using Application.Exceptions;
using Application.Interfaces.UnitOfWork;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Category.Commands.Update
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Response<string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity =await _unitOfWork.CategoryRepository.GetByIdAsync(request.Id);
            if (entity == null)
            {
                throw new NotFoundException("Category not found ");
            }
            _mapper.Map(request, entity);
            entity.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.CategoryRepository.Update(entity);
            await _unitOfWork.SaveAsync();

            return Response<string>.Success(string.Empty,"updated category successfully");
        }
    }
}
