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
    }
}
