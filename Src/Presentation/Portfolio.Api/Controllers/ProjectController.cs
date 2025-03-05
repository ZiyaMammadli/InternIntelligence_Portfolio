using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Features.Projects.Commands.Create;
using Portfolio.Application.Features.Projects.Commands.Delete;
using Portfolio.Application.Features.Projects.Commands.Update;

namespace Portfolio.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateProjectCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteProductCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
    }
}
