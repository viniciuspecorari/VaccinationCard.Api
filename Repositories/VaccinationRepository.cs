using Azure;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Text.Json;
using VaccinationCard.Api.Application.Commands;
using VaccinationCard.Api.Application.Models;
using VaccinationCard.Api.Application.Notifications;
using VaccinationCard.Api.Contracts;
using VaccinationCard.Api.Data;
using VaccinationCard.Api.Mediatr.Models;

namespace VaccinationCard.Api.Repositories
{
    public class VaccinationRepository : IVaccinationRepository
    {
        private readonly VcDbContext _context;
        private readonly IUserRepository _userRepository;


        public VaccinationRepository(VcDbContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        public IUserRepository UserRepository { get; }

        public async Task<Vaccination> AddVaccination(Vaccination vaccination)
        {
            await _context.Vaccinations.AddAsync(vaccination);
            await _context.SaveChangesAsync();

            return vaccination;
        }

        public async Task<bool> DeleteVaccination(Guid Id)
        {
            var vaccination = await _context.Vaccinations.FindAsync(Id);

            _context.Remove(vaccination);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Vaccination> GetVaccinationByCommand(AddVaccinationCommand addVaccination)
        {
            var vaccination = await _context.Vaccinations
                    .Where(v => v.UserId == addVaccination.UserId &&
                                v.VaccineId == addVaccination.VaccineId &&
                                v.DoseId == addVaccination.DoseId)
                    .FirstOrDefaultAsync();

            return vaccination;
        }

        public async Task<string> GetVaccinationsByUserId(Guid userId)
        {
            var user = await _userRepository.GetById(userId);

            var userVaccinationsJson = new
            {
                Name = user.Name,
                Vaccinations = user.Vaccinations
                    .GroupBy(v => v.Vaccine.Name) // Agrupa as vacinações pelo nome da vacina
                    .Select(group => new
                    {
                        VaccineName = group.Key,
                        Doses = group.Select(v => new
                        {
                            DoseId = v.DoseId,
                            CreatedAt = v.CreatedAt
                        }).ToList()
                    }).ToList()
            };

            var options = new JsonSerializerOptions
            {
                WriteIndented = true 
            };

            return JsonSerializer.Serialize(userVaccinationsJson, options);
        }

        public async Task<int> NumberOfDoses(Guid UserId, Guid VaccineId)
        {
            int doses = await _context.Vaccinations.Where(v => v.UserId == UserId &&
                                v.VaccineId == VaccineId).CountAsync();

            return doses;
        }
    }
}
