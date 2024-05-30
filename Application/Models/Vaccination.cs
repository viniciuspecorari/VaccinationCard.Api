using VaccinationCard.Api.Mediatr.Models;

namespace VaccinationCard.Api.Application.Models
{
    public class Vaccination
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User Users { get; set; }
        public Guid VaccineId { get; set; }
        public Vaccine Vaccine { get; set; }
        public int DoseId { get; set; }
        public Dose Dose { get; set; }
        public DateTime CreatedAt { get; set; }        
    }
}
