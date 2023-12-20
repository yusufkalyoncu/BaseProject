using System;
using BaseProject.Application.Abstractions.AuthAbstractions;
using BaseProject.Application.Abstractions.TokenAbstractions;
using BaseProject.Application.Abstractions.UserAbstractions;
using BaseProject.Application.Constants;
using BaseProject.Application.DTOs;
using BaseProject.Application.DTOs.AuthenticationDto;
using BaseProject.Application.Exceptions.AuthExceptions;
using BaseProject.Application.Exceptions.Commons;
using BaseProject.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BaseProject.Persistence.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly IUserService _userService;
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly ITokenHandler _tokenHandler;

        public AuthService(UserManager<UserEntity> userManager, IUserService userService, SignInManager<UserEntity> signInManager, ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _userService = userService;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<TokenDto> LoginAsync(LoginUserRequestDto request)
        {
            var user = await _userManager.FindByNameAsync(request.UsernameOrEmail);

            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(request.UsernameOrEmail);
            }

            if (user == null)
            {
                throw new InvalidCredentialException();
            }

            SignInResult loginResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (loginResult.Succeeded)
            {
                TokenDto token = await _tokenHandler.CreateAccessToken(user);
                await _userService.UpdateRefreshToken(token.RefreshToken, user, token.Expiration.AddMinutes(TokenConst.RefreshTokenExtraTime));

                return token;
            }

            throw new InvalidCredentialException();
        }

        public async Task<TokenDto> RefreshToken(string refreshToken)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(
                u => u.RefreshToken == refreshToken &&
                u.RefreshTokenExpireAt > DateTime.UtcNow);

            if (user != null)
            {
                TokenDto token = await _tokenHandler.CreateAccessToken(user);
                await _userService.UpdateRefreshToken(token.RefreshToken, user, token.Expiration.AddMinutes(TokenConst.RefreshTokenExtraTime));

                return token;
            }
            throw new UnauthorizedException();
        }
    }
}

