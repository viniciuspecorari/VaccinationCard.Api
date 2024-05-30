using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using VaccinationCard.Api.Application.Commands;
using VaccinationCard.Api.Application.Notifications;
using VaccinationCard.Api.Application.Queries;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace VaccinationCard.Api.Controllers
{
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
        public async Task<IActionResult> GetVaccinationsByUserId([FromQuery] GetVaccinationsQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}
