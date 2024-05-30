using MediatR;
using VaccinationCard.Api.Application.Commands;
using VaccinationCard.Api.Application.Models;
using VaccinationCard.Api.Application.Notifications;
using VaccinationCard.Api.Contracts;

namespace VaccinationCard.Api.Application.Handlers
{
    public class AddVaccineCommandHandler : IRequestHandler<AddVaccineCommand, VaccineNotification>
    {
        private readonly IMediator _mediator;
        private readonly IVaccineRepository _vaccineRepository;

        public AddVaccineCommandHandler(IMediator mediator, IVaccineRepository vaccineRepository)
        {
            _mediator = mediator;
            _vaccineRepository = vaccineRepository;
        }
        public async Task<VaccineNotification> Handle(AddVaccineCommand request, CancellationToken cancellationToken)
        {
            var newVaccine = new Vaccine
            {
                Name = request.Name,
            };

            try
            {
                var addVaccine = await _vaccineRepository.AddVaccine(newVaccine);
                await _mediator.Publish(new VaccineNotification(addVaccine.Id, addVaccine.Name));
                return await Task.FromResult(addVaccine);
            }
            catch (Exception ex) 
            {
                throw new ErrorNotification(StatusCodes.Status500InternalServerError, "The Vaccine could not be registered", ex.Message);
            }
        }
    }
}
