using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Features.ContactForms.Commands.SubmitForm;
using Portfolio.Application.Features.ContactForms.Queries.GetAll;

namespace Portfolio.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactFormController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactFormController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllContactForms()
        {
            var response = await _mediator.Send(new GetAllContactFormQueryRequest());
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitForm(SubmitFormCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        
    }
}
