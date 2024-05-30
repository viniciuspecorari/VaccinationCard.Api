using MediatR;
using VaccinationCard.Api.Mediatr.Models;

namespace VaccinationCard.Api.Mediatr.Dtos
{
    public record UserNotifications(Guid Id, string Name) : INotification
    {
        public static implicit operator UserNotifications(User entity)
        {
            return new UserNotifications(entity.Id, entity.Name);
        }
    }
}
