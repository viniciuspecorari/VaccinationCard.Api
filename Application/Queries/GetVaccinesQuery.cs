using MediatR;
using VaccinationCard.Api.Application.Notifications;

namespace VaccinationCard.Api.Application.Queries
{
    public class GetVaccinesQuery : IRequest<IList<VaccineNotification>>
    {
    }
}
