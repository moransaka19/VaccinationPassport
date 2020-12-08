using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Pet : BaseEntity
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
        public IEnumerable<Passport> Passports { get; set; }

        public Pet()
        {
            Passports = new List<Passport>();
        }
    }
}
