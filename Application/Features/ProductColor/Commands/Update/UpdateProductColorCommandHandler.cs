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

namespace Application.Features.ProductColor.Commands.Update
{
    public class UpdateProductColorCommandHandler : IRequestHandler<UpdateProductColorCommand, Response<string>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductColorCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<string>> Handle(UpdateProductColorCommand request, CancellationToken cancellationToken)
        {
            var productColor = await _unitOfWork.ProductColorRepository.GetByIdAsync(request.Id);
            if (productColor == null)
            {
                throw new NotFoundException("product color not found ");
            }
            _mapper.Map(request,productColor);

            _unitOfWork.ProductColorRepository.Update(productColor);
            await _unitOfWork.SaveAsync();

            return Response<string>.Success(string.Empty,"Product Color updated successfully");
        }
    }
}
