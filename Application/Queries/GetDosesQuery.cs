using MediatR;
using VaccinationCard.Api.Application.Notifications;

namespace VaccinationCard.Api.Application.Queries
{
    public class GetDosesQuery : IRequest<IList<DoseNotification>>
    {
    }
}
