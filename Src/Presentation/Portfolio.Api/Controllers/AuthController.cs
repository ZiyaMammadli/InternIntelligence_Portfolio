using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Features.Auth.Commands.Login;
using Portfolio.Application.Features.Auth.Commands.Register;

namespace Portfolio.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginCommandRequest request)
        {
            var response=await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Register(RegisterCommandRequest register)
        {
            await _mediator.Send(register);
            return Ok();
        }
    }
}
