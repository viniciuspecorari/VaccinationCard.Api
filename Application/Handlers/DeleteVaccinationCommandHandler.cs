using MediatR;
using VaccinationCard.Api.Application.Commands;
using VaccinationCard.Api.Application.Notifications;
using VaccinationCard.Api.Contracts;

namespace VaccinationCard.Api.Application.Handlers
{
    public class DeleteVaccinationCommandHandler : IRequestHandler<DeleteVaccinationCommand, StatusNotification>
    {
        private readonly IVaccinationRepository _vaccinationRepository;

        public DeleteVaccinationCommandHandler(IVaccinationRepository vaccinationRepository)
        {
            _vaccinationRepository = vaccinationRepository;
        }

        public async Task<StatusNotification> Handle(DeleteVaccinationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                bool deleted = await _vaccinationRepository.DeleteVaccination(request.VaccinationId);
                if (deleted)
                {
                    return await Task.FromResult(new StatusNotification(StatusCodes.Status200OK, "Vaccination Deleted"));
                }
                throw new Exception("Check that the user exists to be deleted and try again later.");
            }
            catch (Exception ex)
            {
                throw new ErrorNotification(StatusCodes.Status500InternalServerError, "Request could not be processed", ex.Message);
            }
        }
    }
}
