using System;
namespace BaseProject.Application.DTOs.AuthenticationDto
{
    public class LoginUserRequestDto
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
    }
}

