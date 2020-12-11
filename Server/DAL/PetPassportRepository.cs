using DAL.Contexts;
using DAL.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class PetPassportRepository : BaseRepository<PetPassport>, IPetPassportRepository
    {
        public PetPassportRepository(ApplicationContext context)
            : base(context)
        {
        }

        public void UpdateCollar(Collar collar, int petId)
        {
            var pet = GetById(petId);
            pet.Collar = collar;
            context.SaveChanges();
        }

        public void UpdateIdealBloodTest(PetPassport pet, BloodTest blood)
        {
            pet.IdealBloodTest = blood;

            context.SaveChanges();
        }
    }
}
