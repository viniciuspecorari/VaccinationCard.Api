using MediatR;
using VaccinationCard.Api.Mediatr.Dtos;

namespace VaccinationCard.Api.Application.Commands
{
    public class AddUserCommand : IRequest<UserNotifications>
    {
        public string Name { get; set; }
    }
}
