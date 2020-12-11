using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IRecordService
    {
        void AddStartRecord(DateTime date, BloodTest bloodTest, int petId, int vaccinationId);
        void AddInProgressRecord(DateTime date, BloodTest bloodTest, int petId, int vaccinationId);
        void AddFinishRecord(DateTime date, BloodTest bloodTest, int petId, int vaccinationId);
    }
}
