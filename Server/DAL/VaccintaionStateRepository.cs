using DAL.Contexts;
using DAL.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class VaccintaionStateRepository : BaseRepository<VaccinationState>, IVaccinationStateRepository
    {
        public VaccintaionStateRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}
