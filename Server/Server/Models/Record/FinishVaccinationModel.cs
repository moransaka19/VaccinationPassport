using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models.Record
{
    public class FinishVaccinationModel
    {
        public DateTime Date { get; set; }
        public int PetId { get; set; }
        public int VaccinationId { get; set; }
        public float WBS { get; set; }
        public float Eosinophill { get; set; }
        public float Neutrophill { get; set; }
    }
}
