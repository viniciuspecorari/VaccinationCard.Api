using MediatR;
using VaccinationCard.Api.Application.Notifications;

namespace VaccinationCard.Api.Application.Commands
{
    public class AuthCommand : IRequest<AuthNotification>
    {
        public string Credential { get; set; }
    }
}
