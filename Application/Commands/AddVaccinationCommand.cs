using MediatR;
using VaccinationCard.Api.Application.Notifications;

namespace VaccinationCard.Api.Application.Commands
{
    public class AddVaccinationCommand : IRequest<VaccinationNotification>
    {
        public Guid UserId { get; set; }
        public Guid VaccineId { get; set;}
        public int DoseId { get; set; }
    }
}
