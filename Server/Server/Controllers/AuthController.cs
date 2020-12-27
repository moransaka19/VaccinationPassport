﻿using System;
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
    [Authorize]
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

        [AllowAnonymous]
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok(new Test { Id = 1, TestName = "test", TestCur = "test" });
        }

        [AllowAnonymous]
        [HttpPost("registration")]
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

            var user = _userService.Register(model.Login, model.Name, model.Password, model.IsDoctor);
            var accessToken = new AccessToken() { Token = _tokenService.GenerateJwtToken(user) };

            //Response.Cookies.Append("accessToken", accessToken, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Strict });


            return Ok(accessToken);
        }

        [AllowAnonymous]
        [HttpPost("login")]
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

            var accessToken = new AccessToken() { Token = _tokenService.GenerateJwtToken(user) };

            //Response.Cookies.Append("accessToken", accessToken, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Strict });

            return Ok(accessToken);
        }

        [HttpGet("current")]
        public IActionResult GetCurrentUser()
        {
            if (!(Request.Headers.TryGetValue("Authorization", out var requestAccessToken)))
            {
                return Unauthorized(new ErrorMessageModel()
                {
                    Message = "Token is not valid"
                });
            }

            return Ok(_userService.GetCurrentUser(_tokenService.GetCurrentToken(requestAccessToken)));
        }

        [AllowAnonymous]
        [HttpPost("is-login-taken")]
        public bool IsLoginTaken([FromBody] IsLoginTakenModel model)
        {
            return _userService.IsLoginTaken(model.Login);
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("accessToken");

            return Ok();
        }
    }
}
