using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Models.Record;

namespace Server.Controllers
{
    [Route("api/records")]
    [ApiController]
    public class RecordController : ControllerBase
    {
        private readonly IRecordService _recordService;
        private readonly IBloodTestService _bloodTestService;

        public RecordController(IRecordService recordService,
            IBloodTestService bloodTestService)
        {
            _recordService = recordService;
            _bloodTestService = bloodTestService;
        }

        [Authorize(Roles = "doctor")]
        [HttpPost("start")]
        public IActionResult StartVaccination([FromBody] StartVaccinationModel model)
        {
            var bloodTest = _bloodTestService.CreateBloodTest(model.WBS, model.Eosinophill, model.Neutrophill);
            _recordService.AddRecord(model.Date, bloodTest, model.PetId, model.VaccinationId, "start");

            return Ok();
        }

        [Authorize(Roles = "owner")]
        [HttpPost("progress")]
        public IActionResult AddRecord([FromBody] InProgressVaccinationModel model)
        {
            var bloodTest = _bloodTestService.CreateBloodTest(model.WBS, model.Eosinophill, model.Neutrophill);
            _recordService.AddRecord(model.Date, bloodTest, model.PetId, model.VaccinationId, "process");

            return Ok();
        }

        [Authorize(Roles = "doctor")]
        [HttpPost("finish")]
        public IActionResult FinishVaccination([FromBody] FinishVaccinationModel model)
        {
            var bloodTest = _bloodTestService.CreateBloodTest(model.WBS, model.Eosinophill, model.Neutrophill);
            _recordService.AddRecord(model.Date, bloodTest, model.PetId, model.VaccinationId, "finish");

            return Ok();
        }
    }
}
