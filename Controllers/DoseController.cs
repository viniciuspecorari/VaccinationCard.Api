using MediatR;
using Microsoft.AspNetCore.Mvc;
using VaccinationCard.Api.Application.Notifications;
using VaccinationCard.Api.Application.Queries;

namespace VaccinationCard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DoseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoseNotification>>> Get()
        {
            var query = new GetDosesQuery();
            var doses = await _mediator.Send(query);
            return Ok(doses);
        }
    }
}
