using MediatR;
using VaccinationCard.Api.Mediatr.Dtos;

namespace VaccinationCard.Api.Application.Commands
{
    public class AddUserCommand : IRequest<AddUserNotifications>
    {
        public string Name { get; set; }
    }
}
