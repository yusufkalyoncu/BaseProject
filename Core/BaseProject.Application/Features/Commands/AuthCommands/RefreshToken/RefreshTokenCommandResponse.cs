using System;
namespace BaseProject.Application.Features.Commands.AuthCommands.RefreshToken
{
    public class RefreshTokenCommandResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}

