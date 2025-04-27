using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Response;
using Application.Interfaces.UnitOfWork;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.ProductRating.Commands.Add
{
    public class AddProductRatingCommandHandler : IRequestHandler<AddProductRatingCommand, Response<string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;

        public AddProductRatingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor contextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
        }

        public async Task<Response<string>> Handle(AddProductRatingCommand request, CancellationToken cancellationToken)
        {
            var userId= _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if(userId == null)
            {
                throw new UnauthorizedAccessException("user not authorized");
            }
            var productRating = _mapper.Map<Domain.Entities.ProductRating>(request);

            productRating.DateCreate = DateTime.UtcNow;

            var result = await _unitOfWork.ProductRatingRepository.AddAsync(productRating, cancellationToken);
            await _unitOfWork.SaveAsync();
            if (result <= 0)
            {
                return Response<string>.Fail("could not add product rating");
            }
            return Response<string>.Success(string.Empty, "product rating added successfully");
        }
    }
}
