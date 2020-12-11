using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using static DAL.Interfaces.IBaseRepository;

namespace DAL.Interfaces
{
    public interface IPetPassportRepository : IBaseRepository<PetPassport>
    {
        void UpdateCollar(Collar collar, int petId);
        void UpdateIdealBloodTest(PetPassport pet, BloodTest blood);
    }
}
