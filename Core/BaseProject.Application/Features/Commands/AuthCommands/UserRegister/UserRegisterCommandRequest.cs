using System;
using MediatR;

namespace BaseProject.Application.Features.Commands.AuthCommands.UserRegister
{
    public class UserRegisterCommandRequest : IRequest<UserRegisterCommandResponse>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}

