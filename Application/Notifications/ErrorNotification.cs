using Microsoft.AspNetCore.Http;

namespace VaccinationCard.Api.Application.Notifications
{
    public class ErrorNotification : ApplicationException
    {
        public string StatusCode { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }

    }
}
