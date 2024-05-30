using MediatR;
using VaccinationCard.Api.Application.Notifications;

namespace VaccinationCard.Api.Application.Commands
{
    public class AddVaccineCommand : IRequest<VaccineNotification>
    {
        public string Name { get; set; }
    }
}
