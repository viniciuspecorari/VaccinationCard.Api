using Microsoft.EntityFrameworkCore;
using VaccinationCard.Api.Mediatr.Models;

namespace VaccinationCard.Api.Data
{
    public class VcDbContext : DbContext
    {
        public VcDbContext(DbContextOptions<VcDbContext> options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
