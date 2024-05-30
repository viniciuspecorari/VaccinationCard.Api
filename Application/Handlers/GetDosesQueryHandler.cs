using MediatR;
using VaccinationCard.Api.Application.Notifications;
using VaccinationCard.Api.Application.Queries;
using VaccinationCard.Api.Contracts;

namespace VaccinationCard.Api.Application.Handlers
{
    public class GetDosesQueryHandler : IRequestHandler<GetDosesQuery, IList<DoseNotification>>
    {
        private readonly IDoseRepository _doseRepository;

        public GetDosesQueryHandler(IDoseRepository doseRepository)
        {
            _doseRepository = doseRepository;
        }
        public async Task<IList<DoseNotification>> Handle(GetDosesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var dosesList = await _doseRepository.GetDoses();
                var doses = dosesList.Select(d => new DoseNotification(d.Id, d.DoseType)).ToList();
                return doses;
            }
            catch (Exception ex)
            {
                throw new ErrorNotification(StatusCodes.Status404NotFound, "No dose found. Please load the dose table with the seeds configured in the context.", ex.Message);
            }
        }
    }
}
