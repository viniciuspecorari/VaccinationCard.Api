using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VaccinationCard.Api.Application.Commands;
using VaccinationCard.Api.Application.Queries;

namespace VaccinationCard.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VaccinationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VaccinationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddVaccination(AddVaccinationCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteVaccination(DeleteVaccinationCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetVaccinationsByUserId(Guid userId)
        {
            var query = new GetVaccinationsQuery(userId);
            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}
