using BLL.Interfaces;
using DAL.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class OwnerService : IOwnerService
    {
        private readonly IPetPassportRepository _petPassportRepository;
        private readonly IUserRepository _userRepository;

        public OwnerService(IPetPassportRepository petPassportRepository,
            IUserRepository userRepository)
        {
            _petPassportRepository = petPassportRepository;
            _userRepository = userRepository;
        }

        public void AddPet(int petId, User owner)
        {
            var pet = _petPassportRepository.GetById(petId);

            _userRepository.AddPetPassport(owner, pet);
        }

        public IEnumerable<User> GetAllOwners()
        {

            return _userRepository.GetAll(u => u.Role.Name == "owner");
        }
    }
}
