using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Models.PetPassport;

namespace Server.Controllers
{
    [Authorize]
    [Route("api/pet")]
    [ApiController]
    public class PetPassportController : ControllerBase
    {
        private readonly IPetPassportService _petPassportService;
        private readonly IUserService _userService;
        private readonly IBloodTestService _bloodTestService;
        private readonly IMapper _mapper;

        public PetPassportController(IPetPassportService petPassportService,
            IUserService userService,
            IBloodTestService bloodTestService,
            IMapper mapper)
        {
            _petPassportService = petPassportService;
            _userService = userService;
            _bloodTestService = bloodTestService;
            _mapper = mapper;
        }

        [Authorize(Roles = "doctor")]
        [HttpPost("owner")]
        public IActionResult CreatePetPassport([FromBody] CreatePetPassportModel model)
        {
            var owner = _userService.GetById(model.UserId);
            _petPassportService.CreatePetPassport(_mapper.Map<PetPassport>(model), owner);

            return Ok();
        }

        [HttpGet("owner/{id}")]
        public IActionResult GetAllPetsByOwnerId([FromRoute] int id)
        {
            var pets = _petPassportService.GetAllByOwnerId(id);

            return Ok(pets);
        }

        [Authorize(Roles = "doctor")]
        [HttpPost("collar")]
        public IActionResult UpdateCollar([FromBody] UpdateСollarModel model)
        {
            _petPassportService.UpdateCollar(model.CollarId, model.PetId);

            return Ok();
        }

        [Authorize(Roles = "doctor")]
        [HttpPost("ideal-blood-test")]
        public IActionResult UpdateIdealBloodTest([FromBody] UpdateIdealBloodTestModel model)
        {
            var bloodTest = _bloodTestService.Add(_mapper.Map<BloodTest>(model));
            var pet = _petPassportService.GetById(model.PetId);

            _petPassportService.UpdateIdealBloodTest(pet, bloodTest);
            return Ok();
        }
        
    }
}
