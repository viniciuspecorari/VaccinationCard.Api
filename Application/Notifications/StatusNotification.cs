using MediatR;
using System.Globalization;

namespace VaccinationCard.Api.Application.Notifications
{
    public class StatusNotification : INotification
    {
        public int Code { get; set; }
        public string Detail { get; set; }

        public StatusNotification(int code, string detail)
        {
            Code = code;
            Detail = detail;
        }
    }
}
