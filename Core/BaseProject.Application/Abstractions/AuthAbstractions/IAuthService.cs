using System;
using BaseProject.Application.DTOs;
using BaseProject.Application.DTOs.AuthenticationDto;

namespace BaseProject.Application.Abstractions.AuthAbstractions
{
    public interface IAuthService
    {
        public Task<TokenDto> LoginAsync(LoginUserRequestDto request);
        public Task<TokenDto> RefreshToken(string refreshToken);
    }
}

