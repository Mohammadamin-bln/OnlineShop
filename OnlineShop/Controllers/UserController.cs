using Application.Features.User.Commands.Add;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name ="CreateUser")]
        public async Task<IActionResult> CreateUser(AddUserCommand command)
        {
            var result = await  _mediator.Send(command);
            return Ok(result);
        }
    }
}
