using VaccinationCard.Api.Mediatr.Dtos;
using VaccinationCard.Api.Mediatr.Models;

namespace VaccinationCard.Api.Contracts
{
    public interface IUserRepository
    {
       public Task<User> Add(User user);
       public Task<bool> Delete(Guid id);
       public Task<User> GetById(Guid id);
    }
}
