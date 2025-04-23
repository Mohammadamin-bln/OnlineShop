using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Response;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Product.Commands.Add
{
    public class AddProductCommand : IRequest<Response<long>>
    {
        public int ColorId { get; set; }

        public int BrandId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public SizeOfProduct Size { get; set; }

        public string Description { get; set; }

        public int Stock { get; set; }



        public IFormFile Photo { get; set; }
    }
}
