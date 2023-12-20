using System;
using BaseProject.Application.Exceptions.Commons;

namespace BaseProject.Application.Exceptions.AuthExceptions
{
    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(string? message, object? parameters = null) : base(message, parameters)
        {
        }
        public UserNotFoundException(object? parameters = null) : base("İşlem yapmak istediğiniz kullanıcı bulunamadı", parameters)
        {
        }
    }
}

