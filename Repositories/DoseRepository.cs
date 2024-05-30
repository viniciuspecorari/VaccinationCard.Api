using Microsoft.EntityFrameworkCore;
using VaccinationCard.Api.Application.Models;
using VaccinationCard.Api.Contracts;
using VaccinationCard.Api.Data;

namespace VaccinationCard.Api.Repositories
{
    public class DoseRepository : IDoseRepository
    {
        private readonly VcDbContext _context;

        public DoseRepository(VcDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Dose>> GetDoses()
        {
            var doses = await _context.Doses.ToListAsync();
            return doses;
        }
    }
}
