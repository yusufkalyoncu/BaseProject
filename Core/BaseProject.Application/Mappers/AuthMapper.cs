using System;
using AutoMapper;
using BaseProject.Application.DTOs;
using BaseProject.Application.DTOs.AuthenticationDto;
using BaseProject.Application.DTOs.UserDto;
using BaseProject.Application.Features.Commands.AuthCommands.RefreshToken;
using BaseProject.Application.Features.Commands.AuthCommands.UserLogin;
using BaseProject.Application.Features.Commands.AuthCommands.UserRegister;

namespace BaseProject.Application.Mappers
{
    public class AuthMapper : Profile
    {
        public AuthMapper()
        {
            CreateMap<UserRegisterCommandRequest, CreateUserRequestDto>();
            CreateMap<UserLoginCommandRequest, LoginUserRequestDto>();
            CreateMap<TokenDto, UserLoginCommandResponse>();
            CreateMap<TokenDto, RefreshTokenCommandResponse>();
        }
    }
}

