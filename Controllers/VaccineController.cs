using MediatR;
using Microsoft.AspNetCore.Mvc;
using VaccinationCard.Api.Application.Commands;
using VaccinationCard.Api.Application.Notifications;
using VaccinationCard.Api.Application.Queries;

namespace VaccinationCard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccineController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VaccineController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VaccineNotification>>> Get()
        {
            var query = new GetVaccinesQuery();
            var vaccines = await _mediator.Send(query);
            return Ok(vaccines);
        }

        [HttpPost]
        public async Task<ActionResult<VaccineNotification>> Add(AddVaccineCommand command)
        {
            var newVaccine = await _mediator.Send(command);
            return Ok(newVaccine);
        }
    }
}
