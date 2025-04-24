using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Brand.Commands.Add;
using Application.Features.Product.Commands.Add;
using Application.Features.ProductColor.Commands.Add;
using Application.Features.User.Commands.Add;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddUserCommand, User>();

            CreateMap<AddProductCommand, Product>();

            CreateMap<AddProductColorCommand, ProductColor>();

            CreateMap<AddBrandCommand, Brand>();
        }
    }
}
