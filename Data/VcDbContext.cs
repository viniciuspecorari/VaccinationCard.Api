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

            modelBuilder.Entity<User>()
            .HasMany(u => u.Vaccinations)
            .WithOne(v => v.Users)
            .HasForeignKey(v => v.UserId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Dose>().HasData(
                new Dose { Id = 1, DoseType = "1º Dose" },
                new Dose { Id = 2, DoseType = "2º Dose" },
                new Dose { Id = 3, DoseType = "3º Dose" },
                new Dose { Id = 4, DoseType = "4º Dose (Reforço)" },
                new Dose { Id = 5, DoseType = "5º Dose (Reforço)" }
                );
        }
    }
}
