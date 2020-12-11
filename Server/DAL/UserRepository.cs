using DAL.Contexts;
using DAL.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        protected override IQueryable<User> baseQuery => base.baseQuery
            .Include(u => u.Role);

        public UserRepository(ApplicationContext context)
            : base(context)
        {
        }

        public void AddPetPassport(User owner, PetPassport pet)
        {
            var user = baseQuery.Where(o => o == owner)
                .FirstOrDefault();
            user.Pets.ToList().Add(pet);
            context.SaveChanges();
        }
        public IEnumerable<PetPassport> GetAllPets(int ownerId)
        {
            var owner = baseQuery.Where(u => u.Id == ownerId)
                .FirstOrDefault();
            return owner.Pets;
        }
    }
}
