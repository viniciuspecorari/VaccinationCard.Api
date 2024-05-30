using MediatR;
using VaccinationCard.Api.Mediatr.Dtos;

namespace VaccinationCard.Api.Application.EventHandlers
{
    public class LogEventHandler : INotificationHandler<AddUserNotifications>
    {
        public Task Handle(AddUserNotifications notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"CRIACAO: '{notification.Name}'");
            });
        }
    }
}
