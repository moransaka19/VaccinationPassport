using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Models.Owner;

namespace Server.Controllers
{
    [Route("api/owners")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;
        private readonly IMapper _mapper;

        public OwnerController(IOwnerService ownerService,
            IMapper mapper)
        {
            _ownerService = ownerService;
            _mapper = mapper;
        }

        [Authorize(Roles = "doctor")]
        [HttpGet]
        public IActionResult GettAll()
        {
            return Ok(_mapper.Map<OwnerModel>(_ownerService.GetAllOwners()));
        }
    }
}
