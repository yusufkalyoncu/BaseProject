using System;
using BaseProject.Application.Exceptions.Commons;

namespace BaseProject.Application.Exceptions.AuthExceptions
{
    public class InvalidCredentialException : UnauthorizedException
    {
        public InvalidCredentialException(object? parameters = null) : base("Kullanıcı adı/E-posta veya şifre yanlış", parameters)
        {
        }
    }
}

