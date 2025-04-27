using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Response;
using Application.Exceptions;
using Application.Interfaces.FileService;
using Application.Interfaces.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Application.Features.Product.Commands.Update
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Response<string>>
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public UpdateProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IFileService fileService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        public async Task<Response<string>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            string[] allowedFileExtentions = [".jpg", ".jpeg", ".png"];
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.Id);
            if (product == null)
            {
                throw new NotFoundException("product not found");
            }
            _mapper.Map(request, product);


             var photoPath = await _fileService.SaveFileAsync(request.Photo,allowedFileExtentions);
             product.Photo = photoPath;
            product.UpdatedAt = DateTime.UtcNow;
            
            _unitOfWork.ProductRepository.Update(product);
            await _unitOfWork.SaveAsync();

            return Response<string>.Success(string.Empty, "Data Updated successfully");
        }
    }
}
