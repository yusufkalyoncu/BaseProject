using System;
using BaseProject.Application.Exceptions.Commons;

namespace BaseProject.Application.Exceptions.AuthExceptions
{
    public class PasswordsDontMatchException : BadRequestException
    {
        public PasswordsDontMatchException(object? parameters = null) : base("Şifreler uyuşmuyor", parameters)
        {
        }
    }
}

