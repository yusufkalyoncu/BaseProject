using System;
using BaseProject.Application.DTOs;
using BaseProject.Application.DTOs.UserDto;
using BaseProject.Domain.Entities.Identity;

namespace BaseProject.Application.Abstractions.UserAbstractions
{
    public interface IUserService
    {
        public Task CreateAsync(CreateUserRequestDto request);
        public Task UpdateRefreshToken(string refreshToken, UserEntity user, DateTime refreshTokenExpireAt);
    }
}

