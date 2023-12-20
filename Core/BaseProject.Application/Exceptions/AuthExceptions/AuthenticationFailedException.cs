using System;
using BaseProject.Application.Exceptions.Commons;

namespace BaseProject.Application.Exceptions.AuthExceptions
{
    public class AuthenticationFailedException : UnauthorizedException
    {
        public AuthenticationFailedException(string? message, object? parameters = null) : base(message, parameters)
        {
        }

        public AuthenticationFailedException(object? parameters = null) : base("Kimlik doğrulama başarısız", parameters)
        {
        }
    }
}

