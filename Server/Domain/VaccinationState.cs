using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class VaccinationState : BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<Passport> Passports { get; set; }
        public VaccinationState()
        {
            Passports = new List<Passport>();
        }
    }
}
