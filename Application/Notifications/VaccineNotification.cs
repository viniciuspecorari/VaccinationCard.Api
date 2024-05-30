using MediatR;
using VaccinationCard.Api.Application.Models;

namespace VaccinationCard.Api.Application.Notifications
{
    public record VaccineNotification(Guid Id, string Name) : INotification
    {
        public static implicit operator VaccineNotification(Vaccine entity)
        {
            return new VaccineNotification(entity.Id, entity.Name);
        }
    }
}
