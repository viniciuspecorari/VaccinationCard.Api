using MediatR;
using VaccinationCard.Api.Mediatr.Dtos;

namespace VaccinationCard.Api.Application.EventHandlers
{
    public class LogEventHandler : INotificationHandler<UserNotifications>
    {
        public Task Handle(UserNotifications notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"CRIACAO: '{notification.Name}'");
            });
        }
    }
}
