using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using VaccinationCard.Api.Contracts;
using VaccinationCard.Api.Data;
using VaccinationCard.Api.Mediatr.Dtos;
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

        public async Task<bool> Add(UserNotifications user)
        {
            var newUser = new User
            {
                Name = user.Name
            };

            await _context.Users.AddAsync(newUser);            
            return await _context.SaveChangesAsync() > 0;            
        } 

        public async Task<bool> Delete(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
