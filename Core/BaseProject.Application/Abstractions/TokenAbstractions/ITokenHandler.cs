using System;
using BaseProject.Application.DTOs;
using BaseProject.Domain.Entities.Identity;

namespace BaseProject.Application.Abstractions.TokenAbstractions
{
    public interface ITokenHandler
    {
        Task<TokenDto> CreateAccessToken(UserEntity user);
    }
}

