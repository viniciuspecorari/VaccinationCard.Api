using MediatR;

namespace VaccinationCard.Api.Application.Commands
{
    public class AddUserCommand : IRequest<bool>
    {

        public string Name { get; set; }
    }
}
