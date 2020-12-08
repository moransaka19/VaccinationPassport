using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class PetPassport : BaseEntity
    {
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public float Weight { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int CollarId { get; set; }
        public Collar Collar { get; set; }
        public int IdealBloodTestId { get; set; }
        public BloodTest IdealBloodTest { get; set; }
        public IEnumerable<Record> Passports { get; set; }

        public PetPassport()
        {
            Passports = new List<Record>();
        }
    }
}
