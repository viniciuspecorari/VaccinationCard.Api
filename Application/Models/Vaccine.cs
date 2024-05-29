namespace VaccinationCard.Api.Application.Models
{
    public class Vaccine
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Vaccination> Vaccinations { get; } = new List<Vaccination>();
    }
}
