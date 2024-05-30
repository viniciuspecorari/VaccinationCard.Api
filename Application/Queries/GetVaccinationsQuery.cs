using MediatR;
using VaccinationCard.Api.Application.Models;

namespace VaccinationCard.Api.Application.Queries
{
    public record GetVaccinationsQuery(Guid UserId): IRequest<string>
    {
        public static implicit operator GetVaccinationsQuery(Vaccination entity)
        {
            return new GetVaccinationsQuery(entity.UserId);
        }

    }    
}
