using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dtos.Product;
using Application.Features.Brand.Commands.Add;
using Application.Features.Brand.Commands.Update;
using Application.Features.Product.Commands.Add;
using Application.Features.Product.Commands.Update;
using Application.Features.ProductColor.Commands.Add;
using Application.Features.ProductColor.Commands.Update;
using Application.Features.ProductRating.Commands.Add;
using Application.Features.User.Commands.Add;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region User
            CreateMap<AddUserCommand, User>();
            #endregion

            #region product
            CreateMap<UpdateProductCommand, Product>();
            CreateMap<AddProductCommand, Product>();
            CreateMap<Product, ProductListDto>()
            .ForMember(dest => dest.ColorName, opt => opt.MapFrom(src => src.ProductColor.Name))
            .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name));
            CreateMap<Product, ProductDetailsDto>()
                            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name))
            .ForMember(dest => dest.ColorName, opt => opt.MapFrom(src => src.ProductColor.Name));
            #endregion

            #region ProductColor
            CreateMap<AddProductColorCommand, ProductColor>();
            CreateMap<UpdateProductColorCommand, ProductColor>();
            #endregion

            #region Brand
            CreateMap<AddBrandCommand, Brand>();
            CreateMap<UpdateBrandCommand, Brand>();
            #endregion

            #region ProductRating
            CreateMap<AddProductRatingCommand, ProductRating>();
            #endregion
        }
    }
}
