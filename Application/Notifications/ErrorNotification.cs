using MediatR;

namespace VaccinationCard.Api.Application.Notifications
{
    public class ErrorNotification : ApplicationException
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public string Details { get; set; }

        public ErrorNotification(int statusCode, string errorMessage, string details)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
            Details = details;
        }
    }
}
