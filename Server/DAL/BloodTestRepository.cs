using DAL.Contexts;
using DAL.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using static DAL.Interfaces.IBaseRepository;

namespace DAL
{
    public class BloodTestRepository : BaseRepository<BloodTest>, IBloodTestRepository
    {
        public BloodTestRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}
