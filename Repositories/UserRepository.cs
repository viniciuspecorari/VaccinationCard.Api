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
            var newUser = new User
            {
                Name = user.Name
            };

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return newUser;
        } 

        public async Task<bool> Delete(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
