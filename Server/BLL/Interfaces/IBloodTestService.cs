using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IBloodTestService
    {
        BloodTest CreateBloodTest(float wbs, float eosinophill, float neutrophill);
        BloodTest Add(BloodTest model); 
    }
}
