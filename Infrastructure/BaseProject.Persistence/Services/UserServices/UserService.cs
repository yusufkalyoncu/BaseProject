using System;
using BaseProject.Application.Abstractions.UserAbstractions;
using BaseProject.Application.Constants;
using BaseProject.Application.DTOs.UserDto;
using BaseProject.Application.Exceptions.AuthExceptions;
using BaseProject.Application.Exceptions.Commons;
using BaseProject.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace BaseProject.Persistence.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly RoleManager<RoleEntity> _roleManager;
        private readonly IConfiguration _configuration;

        public UserService(UserManager<UserEntity> userManager, RoleManager<RoleEntity> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task CreateAsync(CreateUserRequestDto request)
        {
            var userEntity = await _userManager.FindByEmailAsync(request.Email);

            if (userEntity != null)
            {
                throw new EmailAlreadyExistsException();
            }

            userEntity = await _userManager.FindByNameAsync(request.Username);

            if (userEntity != null)
            {
                throw new UsernameAlreadyExistsException();
            }

            if (request.Password != request.PasswordConfirm)
            {
                throw new PasswordsDontMatchException();
            }

            UserEntity newUser = new()
            {
                Name = request.Name,
                Surname = request.Surname,
                UserName = request.Username,
                Email = request.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var createUserResult = await _userManager.CreateAsync(newUser, request.Password);

            if (!createUserResult.Succeeded)
            {
                throw new BadRequestException("Kullanıcı oluşturma başarısız", request);
            }

            await _userManager.AddToRoleAsync(newUser, UserRole.USER);
        }

        public async Task UpdateRefreshToken(string refreshToken, UserEntity user, DateTime refreshTokenExpireAt)
        {
            if (user != null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenExpireAt = refreshTokenExpireAt;
                await _userManager.UpdateAsync(user);
            }
            else
            {
                throw new UserNotFoundException();
            }
        }
    }
}

