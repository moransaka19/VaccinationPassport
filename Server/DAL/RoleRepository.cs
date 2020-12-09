using DAL.Contexts;
using DAL.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationContext context)
            : base(context)
        {
        }

        public Role GetDoctor()
        {
            return baseQuery.Where(d => d.Name == "doctor").FirstOrDefault();
        }

        public Role GetOwner()
        {
            return baseQuery.Where(d => d.Name == "owner").FirstOrDefault();
        }
    }
}
