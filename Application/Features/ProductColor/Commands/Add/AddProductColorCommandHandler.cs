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

namespace Application.Features.ProductColor.Commands.Add
{
    public class AddProductColorCommandHandler : IRequestHandler<AddProductColorCommand, Response<bool>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AddProductColorCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<bool>> Handle(AddProductColorCommand request, CancellationToken cancellationToken)
        {
            var checkExists = await _unitOfWork.ProductColorRepository.ExistsAsync(x => x.Name == request.Name);
            if (checkExists)
            {
                throw new ConflictException("this color allready exists");

            }
            var productColor = _mapper.Map<Domain.Entities.ProductColor>(request);

            await _unitOfWork.ProductColorRepository.AddAsync(productColor, cancellationToken);
            await _unitOfWork.SaveAsync();

            return Response<bool>.Success(true, "Color added successfully");
        }
    }
}
