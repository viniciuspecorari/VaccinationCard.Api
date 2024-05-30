using MediatR;
using VaccinationCard.Api.Application.Models;
using VaccinationCard.Api.Mediatr.Models;

namespace VaccinationCard.Api.Application.Notifications
{
    public record VaccinationNotification(Guid Id, Guid UserId, Guid VaccineId, int DoseId, DateTime CreatedAt) : INotification
    {
        public static implicit operator VaccinationNotification(Vaccination entity)
        {
            return new VaccinationNotification(entity.Id, entity.UserId, entity.VaccineId, entity.DoseId, entity.CreatedAt);
        }
    }
}
