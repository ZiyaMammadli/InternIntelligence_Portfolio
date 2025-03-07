using MediatR;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Features.Skills.Commands.Create;
using Portfolio.Application.Features.Skills.Commands.Delete;
using Portfolio.Application.Features.Skills.Commands.Update;
using Portfolio.Application.Features.Skills.Queries.GetAll;

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

        [HttpGet]
        public async Task<IActionResult> GetAllSkills()
        {
            var response=await _mediator.Send(new GetAllSkillRequest());
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSkillCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateSkillCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteSkillCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
    }
}
