using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Vaccination : BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<Record> Passports { get; set; }
        public Vaccination()
        {
            Passports = new List<Record>();
        }
    }
}
