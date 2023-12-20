using System;
using System.Net;

namespace BaseProject.Application.Exceptions.Commons
{
    public class UnauthorizedException : BaseException
    {
        public UnauthorizedException(object? parameters = null) : base(HttpStatusCode.Unauthorized, "UNAUTHORIZED", "Oturumun süresi doldu", parameters)
        {
        }
        public UnauthorizedException(string? message, object? parameters = null) : base(HttpStatusCode.Unauthorized, "UNAUTHORIZED", message, parameters)
        {
        }
    }
}

