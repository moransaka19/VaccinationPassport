using DAL.Contexts;
using DAL.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class CollarRepository : BaseRepository<Collar>, ICollarRepository
    {
        public CollarRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}
