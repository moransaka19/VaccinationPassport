using DAL.Contexts;
using DAL.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class RecordRepository : BaseRepository<Record>, IRecordRepository
    {
        public RecordRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}
