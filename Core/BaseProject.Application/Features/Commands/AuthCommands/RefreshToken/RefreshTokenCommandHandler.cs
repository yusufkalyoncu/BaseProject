using System;
using AutoMapper;
using BaseProject.Application.Abstractions.AuthAbstractions;
using MediatR;

namespace BaseProject.Application.Features.Commands.AuthCommands.RefreshToken
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommandRequest, RefreshTokenCommandResponse>
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public RefreshTokenCommandHandler(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommandRequest request, CancellationToken cancellationToken)
        {
            var token = await _authService.RefreshToken(request.RefreshToken);
            return _mapper.Map<RefreshTokenCommandResponse>(token);
        }
    }
}

