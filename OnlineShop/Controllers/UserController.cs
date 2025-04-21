using Application.Features.User.Commands.Add;
using Application.Features.User.Queries.Login;
using Application.Features.User.Queries.Verify;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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


        [HttpPost(Name ="SignUp")]
        public async Task<IActionResult> CreateUser(AddUserCommand command)
        {
            var result = await  _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("SignIn")]
        public async Task<IActionResult> SignIn([FromQuery] CheckLoginQuery query)
        {
            var result= await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("verify")]
        public async Task<IActionResult> Verify([FromQuery] VerifyOtpQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }


    }
}
