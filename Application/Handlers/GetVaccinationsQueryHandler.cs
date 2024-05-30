using MediatR;
using VaccinationCard.Api.Application.Notifications;
using VaccinationCard.Api.Application.Queries;
using VaccinationCard.Api.Contracts;

namespace VaccinationCard.Api.Application.Handlers
{
    public class GetVaccinationsQueryHandler : IRequestHandler<GetVaccinationsQuery, string>
    {
        private readonly IVaccinationRepository _vaccinationRepository;

        public GetVaccinationsQueryHandler(IVaccinationRepository vaccinationRepository)
        {
            _vaccinationRepository = vaccinationRepository;
        }

        public async Task<string> Handle(GetVaccinationsQuery request, CancellationToken cancellationToken)
        {
            try
            {                
                var vaccinationsUser = await _vaccinationRepository.GetVaccinationsByUserId(request.UserId);
                return await Task.FromResult(vaccinationsUser);
            }
            catch (Exception ex)
            {
                throw new ErrorNotification(StatusCodes.Status404NotFound, "We couldn't find any vaccinations from the user.", ex.Message);
            }
        }
    }
}
