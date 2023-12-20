using System;
using MediatR;

namespace BaseProject.Application.Features.Commands.AuthCommands.UserLogin
{
    public class UserLoginCommandRequest : IRequest<UserLoginCommandResponse>
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
    }
}

