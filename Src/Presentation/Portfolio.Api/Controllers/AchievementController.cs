using MediatR;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Features.Achievements.Commands.Create;
using Portfolio.Application.Features.Achievements.Commands.Update;

namespace Portfolio.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AchievementController : ControllerBase
    {
        private readonly IMediator mediator;

        public AchievementController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateAchievementCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateAchievementCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}
