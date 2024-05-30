using MediatR;
using Microsoft.AspNetCore.Mvc;
using VaccinationCard.Api.Application.Commands;
using VaccinationCard.Api.Application.Notifications;

namespace VaccinationCard.Api.Controllers
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

        [HttpPost]
        public async Task<IActionResult> Add(AddUserCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteUserCommand command)
        {            
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
