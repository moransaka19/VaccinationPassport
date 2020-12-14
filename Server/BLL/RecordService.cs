using BLL.Interfaces;
using DAL.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class RecordService : IRecordService
    {
        private readonly IRecordRepository _recordRepository;
        private readonly IVaccinationRepository _vaccinationRepository;
        private readonly IVaccinationStateRepository _vaccinationStateRepository;
        private readonly IPetPassportRepository _petPassportRepository;

        public RecordService(IRecordRepository recordRepository,
            IVaccinationRepository vaccinationRepository,
            IVaccinationStateRepository vaccinationStateRepository,
            IPetPassportRepository petPassportRepository)
        {
            _recordRepository = recordRepository;
            _vaccinationRepository = vaccinationRepository;
            _vaccinationStateRepository = vaccinationStateRepository;
            _petPassportRepository = petPassportRepository;
        }

        public void AddRecord(DateTime date, BloodTest bloodTest, int petId, int vaccinationId, string status)
        {
            var vaccination = _vaccinationRepository.GetById(vaccinationId);
            var vaccinationState = _vaccinationStateRepository.GetAll(vs => vs.Name == status)
                .FirstOrDefault();
            var pet = _petPassportRepository.GetById(petId);
            var record = new Record()
            {
                Date = date,
                Pet = pet,
                BloodTest = bloodTest,
                Vaccination = vaccination,
                VaccinationState = vaccinationState
            };

            _recordRepository.Add(record);
        }
    }
}
