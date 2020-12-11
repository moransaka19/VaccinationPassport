using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Models.Owner;

namespace Server.Controllers
{
    [Route("api/owners")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public OwnerController(IOwnerService ownerService,
            IUserService userService,
            ITokenService tokenService)
        {
            _ownerService = ownerService;
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost("current-owner/pet-passport")]
        [Authorize(Roles = "doctor")]
        public IActionResult AddPet([FromBody] AddPetIdModel model) 
        {
            if (!(Request.Cookies.TryGetValue("accessToken", out var requestAccessToken)))
            {
                return Unauthorized(new ErrorMessageModel()
                {
                    Message = "Token is not valid"
                });
            }

            var user = _userService.GetCurrentUser(_tokenService.GetCurrentToken(requestAccessToken));

            _ownerService.AddPet(model.Id, user);

            return Ok();
        }
    }
}
