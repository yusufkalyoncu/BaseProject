using System;
namespace BaseProject.Application.Features.Commands.AuthCommands.UserLogin
{
    public class UserLoginCommandResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}

