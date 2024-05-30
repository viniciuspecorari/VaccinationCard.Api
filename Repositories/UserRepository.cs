using Microsoft.EntityFrameworkCore;
using VaccinationCard.Api.Contracts;
using VaccinationCard.Api.Data;
using VaccinationCard.Api.Mediatr.Models;

namespace VaccinationCard.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly VcDbContext _context;

        public UserRepository(VcDbContext context)
        {
            _context = context;
        }

        public async Task<User> Add(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        } 

        public async Task<bool> Delete(Guid id)
        {
            var user = await _context.Users
            .Include(u => u.Vaccinations)
            .FirstOrDefaultAsync(u => u.Id == id);

            _context.Users.Remove(user);            
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<User> GetById(Guid id)
        {
            var user = await _context.Users
            .Include(u => u.Vaccinations)
            .ThenInclude(v => v.Vaccine)
            .Include(u => u.Vaccinations)
            .ThenInclude(v => v.Dose)
            .FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

    }
}
