using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Response;
using MediatR;

namespace Application.Features.ProductOffer.Commands.Add
{
    public class AddProductOfferCommand : IRequest<Response<string>>
    {
        public long ProductId { get; set; }
        public long OfferId { get; set; }
    }
}
