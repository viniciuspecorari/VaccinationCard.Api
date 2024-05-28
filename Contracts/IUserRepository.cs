using VaccinationCard.Api.Mediatr.Dtos;

namespace VaccinationCard.Api.Contracts
{
    public interface IUserRepository
    {
       public Task<bool> Add(UserNotifications user);
       public Task<bool> Delete(Guid id);
    }
}
