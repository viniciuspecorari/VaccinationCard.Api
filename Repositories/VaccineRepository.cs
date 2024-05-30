using Microsoft.EntityFrameworkCore;
using VaccinationCard.Api.Application.Models;
using VaccinationCard.Api.Contracts;
using VaccinationCard.Api.Data;

namespace VaccinationCard.Api.Repositories
{
    public class VaccineRepository : IVaccineRepository
    {
        private readonly VcDbContext _context;

        public VaccineRepository(VcDbContext context)
        {
            _context = context;
        }

        public async Task<Vaccine> AddVaccine(Vaccine vaccine)
        {
            await _context.Vaccines.AddAsync(vaccine);
            await _context.SaveChangesAsync();
            return vaccine;
        }

        public async Task<IEnumerable<Vaccine>> GetVaccines()
        {
            var vaccines = await _context.Vaccines.ToListAsync();
            return vaccines;
        }
    }
}
