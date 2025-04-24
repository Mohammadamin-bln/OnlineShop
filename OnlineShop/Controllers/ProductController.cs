using Application.Features.Brand.Commands.Add;
using Application.Features.Brand.Commands.Update;
using Application.Features.Product.Commands.Add;
using Application.Features.Product.Commands.Update;
using Application.Features.ProductColor.Commands.Add;
using Application.Features.ProductColor.Commands.Update;
using Application.Features.User.Commands.Add;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Add/Color")]
        public async Task<IActionResult> CreateProductColor(AddProductColorCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("Add/Brand")]
        public async Task<IActionResult> CreateProductBrand(AddBrandCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("Add/Product")]
        public async Task<IActionResult> CreateProduct(AddProductCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("Update/Product")]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("Update/Color")]
        public async Task<IActionResult> UpdateProductColor(UpdateProductColorCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("Update/Brand")]
        public async Task<IActionResult> UpdateBrand(UpdateBrandCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
