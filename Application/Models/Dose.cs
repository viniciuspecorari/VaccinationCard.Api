namespace VaccinationCard.Api.Application.Models
{
    public class Dose
    {
        public int Id { get; set; }
        public string DoseType  { get; set; }
        public ICollection<Vaccination> Vaccinations { get; } = new List<Vaccination>();
    }
}
