using DAL.Contexts;
using DAL.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class VaccinationRepository : BaseRepository<Vaccination>, IVaccinationRepository
    {
        public VaccinationRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}
