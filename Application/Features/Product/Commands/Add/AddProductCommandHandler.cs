using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Response;
using Application.Interfaces.FileService;
using Application.Interfaces.UnitOfWork;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Product.Commands.Add
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, Response<long>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public AddProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _fileService = fileService;
        }

        public async Task<Response<long>> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            string[] allowedFileExtentions = [".jpg", ".jpeg", ".png"];
            string createdImageName = await _fileService.SaveFileAsync(request.Photo, allowedFileExtentions);

            var product = _mapper.Map<Domain.Entities.Product>(request);

            product.Photo = createdImageName;
            product.DateCreate = DateTime.UtcNow;


            await _unitOfWork.ProductRepository.AddAsync(product,cancellationToken);
            await _unitOfWork.SaveAsync();

            return Response<long>.Success(product.Id);
            
                
            
        }
    }
}
