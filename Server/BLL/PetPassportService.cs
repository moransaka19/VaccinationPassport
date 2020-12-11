using BLL.Interfaces;
using DAL.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class PetPassportService : IPetPassportService
    {
        private readonly IPetPassportRepository _petPassportRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICollarRepository _collarRepository;

        public PetPassportService(IPetPassportRepository petPassportRepository,
            IUserRepository userRepository,
            ICollarRepository collarRepository)
        {
            _petPassportRepository = petPassportRepository;
            _userRepository = userRepository;
            _collarRepository = collarRepository;
        }

        public void CreatePetPassport(PetPassport pet, User owner)
        {
            pet.User = owner;

            _petPassportRepository.Add(pet);
        }

        public IEnumerable<PetPassport> GetAllByOwnerId(int ownerId)
        {
            return _userRepository.GetAllPets(ownerId);
        }

        public void UpdateCollar(int collarId, int petId)
        {
            var collar = _collarRepository.GetById(collarId);
            _petPassportRepository.UpdateCollar(collar, petId);
        }

        public void UpdateIdealBloodTest(PetPassport pet, BloodTest blood)
        {
            _petPassportRepository.UpdateIdealBloodTest(pet, blood);
        }

        public PetPassport GetById(int id)
        {
            return _petPassportRepository.GetById(id);
        }
    }
}
