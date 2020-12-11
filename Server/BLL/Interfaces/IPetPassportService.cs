using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IPetPassportService
    {
        void CreatePetPassport(PetPassport pet, User owner);
        IEnumerable<PetPassport> GetAllByOwnerId(int ownerId);
        void UpdateCollar(int collarId, int petId);
        void UpdateIdealBloodTest(PetPassport pet, BloodTest blood);
        PetPassport GetById(int id);
    }
}
