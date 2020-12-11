using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL;
using BLL.Interfaces;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Models.Auth;

namespace Server.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AuthController(IUserService userService,
            ITokenService tokenService,
            IMapper mapper)
        {
            _userService = userService;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        [HttpPost("registration")]
        [AllowAnonymous]
        public IActionResult Registration([FromBody] RegisterModel model)
        {
            if (_userService.IsLoginTaken(model.Login))
            {
                return BadRequest(new ErrorMessageModel()
                {
                    Message = "Login is taken"
                });
            }

            if (_userService.IsNameTaken(model.Name))
            {
                return BadRequest(new ErrorMessageModel()
                {
                    Message = "Name is taken"
                });
            }

            _userService.Register(model.Login, model.Name, model.Password, model.IsDoctor);
            var accessToken = _tokenService.GenerateJwtToken(_mapper.Map<User>(model));

            Response.Cookies.Append("accessToken", accessToken, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Strict });


            return Ok();
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginModel model) 
        {
            var user = _userService.Authenticate(_mapper.Map<User>(model));

            if (user == null)
            {
                return Unauthorized(new ErrorMessageModel()
                {
                    Message = "login or password are incorrect"
                });
            }

            var accessToken = _tokenService.GenerateJwtToken(user);
            Response.Cookies.Append("accessToken", accessToken, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Strict });

            return Ok();
        }

        [HttpPost("is-login-taken")]
        [AllowAnonymous]
        public bool IsLoginTaken([FromBody] IsLoginTakenModel model) 
        {
            return _userService.IsLoginTaken(model.Login);
        }

        [HttpPost("logout")]
        public IActionResult Logout() 
        {
            Response.Cookies.Delete("accessToken");

            return Ok();
        }
    }
}
