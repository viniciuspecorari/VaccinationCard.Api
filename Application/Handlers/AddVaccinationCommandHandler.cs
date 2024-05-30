using MediatR;
using VaccinationCard.Api.Application.Commands;
using VaccinationCard.Api.Application.Models;
using VaccinationCard.Api.Application.Notifications;
using VaccinationCard.Api.Contracts;

namespace VaccinationCard.Api.Application.Handlers
{
    public class AddVaccinationCommandHandler : IRequestHandler<AddVaccinationCommand, VaccinationNotification>
    {
        private readonly IVaccinationRepository _vaccinationRepository;

        public AddVaccinationCommandHandler(IVaccinationRepository vaccinationRepository)
        {
            _vaccinationRepository = vaccinationRepository;
        }
        public async Task<VaccinationNotification> Handle(AddVaccinationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var vaccination = await _vaccinationRepository.GetVaccinationByCommand(request);
                if (vaccination is null)
                {
                    int doses = await _vaccinationRepository.NumberOfDoses(request.UserId, request.VaccineId);
                    if (doses+1 == request.DoseId && doses < 6) // O usuário não pode burlar a ordem das doses
                    {
                        var newVaccination = new Vaccination
                        {
                            UserId = request.UserId,
                            VaccineId = request.VaccineId,
                            DoseId = request.DoseId,
                            CreatedAt = DateTime.Now
                        };

                        var response = await _vaccinationRepository.AddVaccination(newVaccination);
                        return await Task.FromResult(new VaccinationNotification(response.Id, response.UserId, response.VaccineId, response.DoseId, response.CreatedAt));
                    }
                    throw new Exception("The user has already exceeded the dose limit or has no previous doses recorded. Review the doses already taken and record the correct dose.");
                }
                throw new Exception("It is not possible to record the same dose more than once.");
            }
            catch (Exception ex)
            {
                throw new ErrorNotification(StatusCodes.Status500InternalServerError, "An error occurred in the application", ex.Message);
            }
        }
    }
}
