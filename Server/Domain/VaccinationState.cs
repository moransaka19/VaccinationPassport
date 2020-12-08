using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class VaccinationState : BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<Record> Passports { get; set; }
        public VaccinationState()
        {
            Passports = new List<Record>();
        }
    }
}
