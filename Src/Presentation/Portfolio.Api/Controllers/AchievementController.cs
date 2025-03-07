using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Features.Achievements.Commands.Create;
using Portfolio.Application.Features.Achievements.Commands.Delete;
using Portfolio.Application.Features.Achievements.Commands.Update;
using Portfolio.Application.Features.Achievements.Queries.GetAll;

namespace Portfolio.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class AchievementController : ControllerBase
    {
        private readonly IMediator mediator;

        public AchievementController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAchievements()
        {
            var resonse = await mediator.Send(new GetAllAchievementRequest());
            return Ok(resonse);
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
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteAchievementCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
        
    }
}
