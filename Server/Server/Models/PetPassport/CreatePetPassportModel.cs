using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models.PetPassport
{
    public class CreatePetPassportModel
    {
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public float Weight { get; set; }
        public int UserId { get; set; }
    }
}
