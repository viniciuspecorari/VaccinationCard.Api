namespace VaccinationCard.Api.Application.Models
{
    public class Dose
    {
        public Guid Id { get; set; }
        public DoseType DoseType  { get; set; }
        public ICollection<Vaccination> Vaccinations { get; } = new List<Vaccination>();
    }

    public enum DoseType
    {
        PrimeiraDose,
        SegundaDose,
        TerceiraDose,
        PrimeiroReforco,
        SegundoReforco,          
    }
}
