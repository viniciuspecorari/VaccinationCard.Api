﻿using VaccinationCard.Api.Application.Models;

namespace VaccinationCard.Api.Mediatr.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Vaccination> Vaccinations { get; } = new List<Vaccination>();
    }
}
