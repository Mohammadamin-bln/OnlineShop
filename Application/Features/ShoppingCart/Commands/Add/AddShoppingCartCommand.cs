using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Response;
using MediatR;

namespace Application.Features.ShoppingCart.Commands.Add
{
    public class AddShoppingCartCommand : IRequest<Response<string>>
    {
        public long ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
