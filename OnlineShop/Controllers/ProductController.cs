using Application.Common.PaginatedResponse;
using Application.Dtos.Product;
using Application.Features.Brand.Commands.Add;
using Application.Features.Brand.Commands.Update;
using Application.Features.Brand.Queries.GetById;
using Application.Features.Brand.Queries.GetList;
using Application.Features.Category.Commands.Add;
using Application.Features.Category.Commands.Update;
using Application.Features.Category.Queries.GetById;
using Application.Features.Category.Queries.GetList;
using Application.Features.Offer.Commands;
using Application.Features.Product.Commands.Add;
using Application.Features.Product.Commands.Update;
using Application.Features.Product.Queries.GetById;
using Application.Features.Product.Queries.GetPaginated;
using Application.Features.ProductColor.Commands.Add;
using Application.Features.ProductColor.Commands.Update;
using Application.Features.ProductColor.Queries.GetById;
using Application.Features.ProductColor.Queries.GetList;
using Application.Features.ProductOffer.Commands.Add;
using Application.Features.ProductRating.Commands.Add;
using Application.Features.User.Commands.Add;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

        [HttpGet("Get/Product/List")]
        public async Task<ActionResult> GetPaginatedProducts([FromQuery] GetListOfProductsQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [Authorize]
        [HttpPost("Add/Product/Rating")]
        public async Task<IActionResult> AddProductRating(AddProductRatingCommand command)
        {
            var result= await _mediator.Send(command);
            return Ok(result);
        }
        

        [HttpGet("Get/Product/By/Id")]
        public async Task<IActionResult> GetProductById([FromQuery]GetProductByIdQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("Get/Brand/List")]
        public async Task<IActionResult> GetBrandList([FromQuery]GetBrandListQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("Get/Color/List")]
        public async Task<IActionResult> GetColorList([FromQuery] GetProductColorListQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("Add/Category")]
        public async Task<IActionResult> AddCategory(AddCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPost("Add/Offer")]
        public async Task<IActionResult> AddOffer(AddOfferCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("Apply/Offer/To/Product")]
        public async Task<IActionResult> ApplyOffer(AddProductOfferCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPut("Update/Category")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("Get/Category/List")]
        public async  Task<IActionResult> GetCategoryList([FromQuery]GetCategoryListQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("Get/Brand/By/Id")]
        public async Task<IActionResult> GetBrandById([FromQuery] GetBrandByIdQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("Get/Category/By/Id")]
        public async Task<IActionResult> GetCategoryById([FromQuery] GetCategoryByIdQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("Get/Color/By/Id")]
        public async Task<IActionResult> GetColorById([FromQuery] GetProductColorByIdQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
