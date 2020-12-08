using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Passport : BaseEntity
    {
        public DateTime Date { get; set; }
        public int PetId { get; set; }
        public Pet Pet { get; set; }
        public int VaccinationStateId { get; set; }
        public VaccinationState VaccinationState { get; set; }
        public int VaccinationId { get; set; }
        public Vaccination Vaccination { get; set; }
        public int BloodTestId { get; set; }
        public BloodTest BloodTest { get; set; }
    }
}
