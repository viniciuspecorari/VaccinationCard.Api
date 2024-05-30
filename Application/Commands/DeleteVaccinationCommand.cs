using MediatR;
using VaccinationCard.Api.Application.Notifications;

namespace VaccinationCard.Api.Application.Commands
{
    public class DeleteVaccinationCommand : IRequest<StatusNotification>
    {
        public Guid VaccinationId { get; set; }
    }
}
