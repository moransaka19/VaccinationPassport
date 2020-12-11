using BLL.Interfaces;
using DAL.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class BloodTestService : IBloodTestService
    {
        private readonly IBloodTestRepository _bloodTestRepository;

        public BloodTestService(IBloodTestRepository bloodTestRepository)
        {
            _bloodTestRepository = bloodTestRepository;
        }

        public BloodTest CreateBloodTest(float wbs, float eosinophill, float neutrophill)
        {
            return new BloodTest()
            {
                WBS = wbs,
                Eosinophill = eosinophill,
                Neutrophill = neutrophill
            };
        }

        public BloodTest Add(BloodTest model)
        {
            return _bloodTestRepository.AddBloodTest(model);
        }
    }
}
