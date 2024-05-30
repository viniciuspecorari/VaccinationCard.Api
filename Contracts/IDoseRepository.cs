using System.Runtime.CompilerServices;
using VaccinationCard.Api.Application.Models;

namespace VaccinationCard.Api.Contracts
{
    public interface IDoseRepository
    {
        Task<IEnumerable<Dose>> GetDoses();
    }
}
