using System;
using BaseProject.Application.Exceptions.Commons;

namespace BaseProject.Application.Exceptions.AuthExceptions
{
    public class EmailAlreadyExistsException : ConflictException
    {
        public EmailAlreadyExistsException(string? message, object? parameters = null) : base(message, parameters)
        {
        }
        public EmailAlreadyExistsException(object? parameters = null) : base("Bu e-posta adresi zaten kullanılıyor", parameters)
        {
        }
    }
}

