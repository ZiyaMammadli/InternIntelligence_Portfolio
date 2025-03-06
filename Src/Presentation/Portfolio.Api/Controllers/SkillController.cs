using MediatR;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Features.Skills.Commands.Create;

namespace Portfolio.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SkillController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSkillCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
    }
}
