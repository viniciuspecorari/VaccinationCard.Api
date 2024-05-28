using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VaccinationCard.Api.Application.Commands;
using VaccinationCard.Api.Contracts;
using VaccinationCard.Api.Mediatr.Dtos;

namespace VaccinationCard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserRepository _userRepository;

        public UserController(IMediator mediator, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddUserCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid Id)
        {
            return Ok();
        }
    }
}
