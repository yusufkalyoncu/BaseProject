using System;
using AutoMapper;
using BaseProject.Application.Abstractions.UserAbstractions;
using BaseProject.Application.Constants;
using BaseProject.Application.DTOs.UserDto;
using BaseProject.Application.Exceptions.AuthExceptions;
using BaseProject.Application.Exceptions.Commons;
using BaseProject.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace BaseProject.Application.Features.Commands.AuthCommands.UserRegister
{
    public class UserRegisterCommandHandler : IRequestHandler<UserRegisterCommandRequest, UserRegisterCommandResponse>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserRegisterCommandHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<UserRegisterCommandResponse> Handle(UserRegisterCommandRequest request, CancellationToken cancellationToken)
        {
            var requestModel = _mapper.Map<CreateUserRequestDto>(request);
            await _userService.CreateAsync(requestModel);

            return new()
            {
                Email = request.Email,
                Username = request.Username
            };
        }
    }
}

