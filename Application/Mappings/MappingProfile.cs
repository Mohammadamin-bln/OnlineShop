using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Brand.Commands.Add;
using Application.Features.Brand.Commands.Update;
using Application.Features.Product.Commands.Add;
using Application.Features.Product.Commands.Update;
using Application.Features.ProductColor.Commands.Add;
using Application.Features.ProductColor.Commands.Update;
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
            #endregion

            #region ProductColor
            CreateMap<AddProductColorCommand, ProductColor>();
            CreateMap<UpdateProductColorCommand, ProductColor>();
            #endregion

            #region Brand
            CreateMap<AddBrandCommand, Brand>();
            CreateMap<UpdateBrandCommand, Brand>();
            #endregion
        }
    }
}
