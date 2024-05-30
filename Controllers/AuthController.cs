using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VaccinationCard.Api.Application.Commands;

namespace VaccinationCard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Auth(AuthCommand command)
        {
            var auth = await _mediator.Send(command);
            return Ok(auth);
        }
    }
}
