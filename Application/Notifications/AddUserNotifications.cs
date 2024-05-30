using MediatR;
using VaccinationCard.Api.Mediatr.Models;

namespace VaccinationCard.Api.Mediatr.Dtos
{
    public record AddUserNotifications(Guid Id, string Name) : INotification
    {
        public static implicit operator AddUserNotifications(User entity)
        {
            return new AddUserNotifications(entity.Id, entity.Name);
        }
    }
}
