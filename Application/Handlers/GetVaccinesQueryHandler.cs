using MediatR;
using VaccinationCard.Api.Application.Notifications;
using VaccinationCard.Api.Application.Queries;
using VaccinationCard.Api.Contracts;

namespace VaccinationCard.Api.Application.Handlers
{
    public class GetVaccinesQueryHandler : IRequestHandler<GetVaccinesQuery, IList<VaccineNotification>>
    {
        private readonly IVaccineRepository _vaccineRepository;

        public GetVaccinesQueryHandler(IVaccineRepository vaccineRepository)
        {
            _vaccineRepository = vaccineRepository;
        }
        public async Task<IList<VaccineNotification>> Handle(GetVaccinesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var vaccinesList = await _vaccineRepository.GetVaccines();
                var vaccines = vaccinesList.Select(v => new VaccineNotification(v.Id, v.Name)).ToList();
                    
                return vaccines;
            }
            catch (Exception ex) 
            {
                throw new ErrorNotification(StatusCodes.Status404NotFound, "No vaccine found", ex.Message);
            }
        }
    }
}
