using AutoMapper;
using BaseProject.Application.Abstractions.AuthAbstractions;
using BaseProject.Application.DTOs.AuthenticationDto;
using MediatR;

namespace BaseProject.Application.Features.Commands.AuthCommands.UserLogin
{
    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommandRequest, UserLoginCommandResponse>
    {
        private readonly IAuthService _authenticationService;
        private readonly IMapper _mapper;

        public UserLoginCommandHandler(IAuthService authenticationService, IMapper mapper)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
        }

        public async Task<UserLoginCommandResponse> Handle(UserLoginCommandRequest request, CancellationToken cancellationToken)
        {
            var requestModel = _mapper.Map<LoginUserRequestDto>(request);

            var token = await _authenticationService.LoginAsync(requestModel);

            return _mapper.Map<UserLoginCommandResponse>(token);
        }
    }
}

