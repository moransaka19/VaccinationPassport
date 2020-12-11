using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models.PetPassport
{
    public class UpdateIdealBloodTestModel
    {
        public float WBS { get; set; }
        public float Eosinophill { get; set; }
        public float Neutrophill { get; set; }
        public int PetId { get; set; }
    }
}
