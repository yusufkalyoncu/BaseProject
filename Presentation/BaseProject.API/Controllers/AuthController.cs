using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseProject.Application.Features.Commands.AuthCommands.RefreshToken;
using BaseProject.Application.Features.Commands.AuthCommands.UserLogin;
using BaseProject.Application.Features.Commands.AuthCommands.UserRegister;
using BaseProject.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<UserRegisterCommandResponse> Register(UserRegisterCommandRequest request)
        {
            var res = await _mediator.Send(request);
            return res;
        }

        [HttpPost("login")]
        public async Task<UserLoginCommandResponse> Login(UserLoginCommandRequest request)
        {
            var res = await _mediator.Send(request);
            return res;
        }

        [HttpPost("refresh-token")]
        public async Task<RefreshTokenCommandResponse> RefreshToken(RefreshTokenCommandRequest request)
        {
            var res = await _mediator.Send(request);
            return res;
        }

        [Authorize(Roles = "USER")]
        [HttpPost("test-user")]
        public IActionResult TestUser()
        {
            return Ok();
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPost("test-admin")]
        public IActionResult TestAdmin()
        {
            return Ok();
        }

        [Authorize]
        [HttpPost("test-user-admin")]
        public IActionResult TestAdminUser()
        {
            return Ok();
        }
    }
}

