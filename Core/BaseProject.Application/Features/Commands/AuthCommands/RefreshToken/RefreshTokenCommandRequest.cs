using System;
using MediatR;

namespace BaseProject.Application.Features.Commands.AuthCommands.RefreshToken
{
    public class RefreshTokenCommandRequest : IRequest<RefreshTokenCommandResponse>
    {
        public string RefreshToken { get; set; }
    }
}

