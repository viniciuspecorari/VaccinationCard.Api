using Microsoft.EntityFrameworkCore;
using VaccinationCard.Api.Application.Models;
using VaccinationCard.Api.Mediatr.Models;

namespace VaccinationCard.Api.Data
{
    public class VcDbContext : DbContext
    {
        public VcDbContext(DbContextOptions<VcDbContext> options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<Dose> Doses { get; set; }
        public DbSet<Vaccination> Vaccinations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
