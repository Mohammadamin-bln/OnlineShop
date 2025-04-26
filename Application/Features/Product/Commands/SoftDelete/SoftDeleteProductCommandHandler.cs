using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Response;
using Application.Exceptions;
using Application.Interfaces.UnitOfWork;
using MediatR;

namespace Application.Features.Product.Commands.SoftDelete
{
    public class SoftDeleteProductCommandHandler : IRequestHandler<SoftDeleteProductCommand, Response<string>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SoftDeleteProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<string>> Handle(SoftDeleteProductCommand request, CancellationToken cancellationToken)
        {
            var entity= await _unitOfWork.ProductRepository.GetByIdAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException("product with this id  not found ");
            }

            var result= await _unitOfWork.ProductRepository.SoftDelete(entity);
            await _unitOfWork.SaveAsync();

            if (!result)
            {
                throw new SoftDeleteFailedException("Soft delete failed");
            }
            return Response<string>.Success(string.Empty,"successfully deleted product");
                
            
        }
    }
}
