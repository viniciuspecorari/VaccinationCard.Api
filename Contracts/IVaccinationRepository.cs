using VaccinationCard.Api.Application.Commands;
using VaccinationCard.Api.Application.Models;
using VaccinationCard.Api.Application.Notifications;

namespace VaccinationCard.Api.Contracts
{
    public interface IVaccinationRepository
    {
        Task<Vaccination> AddVaccination(Vaccination vaccination);
        Task<Vaccination> GetVaccinationByCommand(AddVaccinationCommand addVaccination);
        Task<int> NumberOfDoses(Guid UserId, Guid VaccineId);
        Task<bool> DeleteVaccination(Guid Id);
        Task<string> GetVaccinationsByUserId(Guid UserId);
    }
}
