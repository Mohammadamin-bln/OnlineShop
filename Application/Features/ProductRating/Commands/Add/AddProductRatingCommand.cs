using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Response;
using MediatR;

namespace Application.Features.ProductRating.Commands.Add
{
    public class AddProductRatingCommand : IRequest<Response<string>>
    {
        public Guid UserId { get; set; }

        public long ProductId { get; set; }

        public int Stars { get; set; }
    }
}
