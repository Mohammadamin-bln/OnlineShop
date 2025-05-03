using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Response;
using Application.Exceptions;
using Application.Interfaces.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Commands.Add
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, Response<string>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public AddCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var exists= await _unitOfWork.CategoryRepository.ExistsAsync(x=>x.Name == request.Name);
            if (exists)
            {
                throw new ConflictException("this category allready exists");
            }
            var category = _mapper.Map<Domain.Entities.Category>(request);

            await _unitOfWork.CategoryRepository.AddAsync(category,cancellationToken);
            await _unitOfWork.SaveAsync();

            return Response<string>.Success(string.Empty, "category added successfully");

        }
    }
}
