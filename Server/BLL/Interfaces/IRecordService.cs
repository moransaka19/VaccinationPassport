using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IRecordService
    {
        void AddRecord(DateTime date, BloodTest bloodTest, int petId, int vaccinationId, string status);
    }
}
