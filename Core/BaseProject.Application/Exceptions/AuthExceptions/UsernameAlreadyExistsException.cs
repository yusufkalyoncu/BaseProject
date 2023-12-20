using System;
using BaseProject.Application.Exceptions.Commons;

namespace BaseProject.Application.Exceptions.AuthExceptions
{
    public class UsernameAlreadyExistsException : ConflictException
    {
        public UsernameAlreadyExistsException(string? message, object? parameters = null) : base(message, parameters)
        {
        }
        public UsernameAlreadyExistsException(object? parameters = null) : base("Bu kullanıcı adı zaten kullanılıyor", parameters)
        {
        }
    }
}

