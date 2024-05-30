using MediatR;

namespace VaccinationCard.Api.Application.Queries
{
    public class GetVaccinationsQuery : IRequest<string>
    {
        public Guid UserId { get; set; }
    }
}
