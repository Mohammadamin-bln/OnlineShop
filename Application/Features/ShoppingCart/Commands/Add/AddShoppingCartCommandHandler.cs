using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Response;
using Application.Exceptions;
using Application.Interfaces.UnitOfWork;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.ShoppingCart.Commands.Add
{
    public class AddShoppingCartCommandHandler : IRequestHandler<AddShoppingCartCommand, Response<string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;

        public AddShoppingCartCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor contextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
        }

        public async Task<Response<string>> Handle(AddShoppingCartCommand request, CancellationToken cancellationToken)
        {
            var userIdString = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userIdString == null)
            {
                throw new UnauthorizedAccessException("user not authorized");
            }
            var userId =Guid.Parse(userIdString);

            var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.ProductId);

            if (product == null)
            {
                throw new NotFoundException("product not found");
            }
            var shoppingCart = new Domain.Entities.ShoppingCart
            {
                DateCreate = DateTime.UtcNow,
                Price = product.Price,
                ProductId = request.ProductId,
                UserId = userId,
                Quantity = request.Quantity,



            };

            var activeOffer= await _unitOfWork.ProductRepository.GetActiveOfferAsync(request.ProductId);
            if (activeOffer != null)
            {
                var discountedPrice = product.Price * (1 - activeOffer.DiscountPercentage / 100m);

                shoppingCart.Price = discountedPrice;
            }
            shoppingCart.Total = shoppingCart.Price * shoppingCart.Quantity;

            await _unitOfWork.ShoppingCartRepository.AddAsync(shoppingCart,cancellationToken);
            await _unitOfWork.SaveAsync();

            return Response<string>.Success(string.Empty, "product added  to shopping cart successfully");


        }
    }
}
