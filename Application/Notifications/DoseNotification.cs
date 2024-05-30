using MediatR;
using System.Runtime.CompilerServices;
using VaccinationCard.Api.Application.Models;

namespace VaccinationCard.Api.Application.Notifications
{
    public record DoseNotification(int Id, string DoseType): INotification
    {
        public static implicit operator DoseNotification(Dose entity)
        {
            return new DoseNotification(entity.Id, entity.DoseType);
        }
    }
}
