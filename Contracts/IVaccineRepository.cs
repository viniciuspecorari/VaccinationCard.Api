using VaccinationCard.Api.Application.Models;

namespace VaccinationCard.Api.Contracts
{
    public interface IVaccineRepository
    {
        Task<Vaccine> AddVaccine(Vaccine vaccine);
        Task<IEnumerable<Vaccine>> GetVaccines();
    }
}
