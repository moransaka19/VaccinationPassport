using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class BloodTest : BaseEntity
    {
        public float WBS { get; set; }
        public float Eosinophill { get; set; }
        public float Neutrophill { get; set; }
        public IEnumerable<Record> Passports { get; set; }
        public BloodTest()
        {
            Passports = new List<Record>();
        }
    }
}
