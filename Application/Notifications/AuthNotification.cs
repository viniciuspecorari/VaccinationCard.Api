using MediatR;
using VaccinationCard.Api.Application.Models;

namespace VaccinationCard.Api.Application.Notifications
{
    public record AuthNotification(string Token, DateTime Expired) : INotification
    {
        public static implicit operator AuthNotification(Auth entity)
        {
            return new AuthNotification(entity.Token, entity.Expired);
        }
    }
}
