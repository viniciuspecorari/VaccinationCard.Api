using VaccinationCard.Api.Application.Models;

namespace VaccinationCard.Api.Contracts
{
    public interface IAuthRepository
    {
        Task<Auth> Authenticate(string credential);
    }
}
