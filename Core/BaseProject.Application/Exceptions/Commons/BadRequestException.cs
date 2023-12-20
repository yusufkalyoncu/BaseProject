using System;
using System.Net;

namespace BaseProject.Application.Exceptions.Commons
{
    public class BadRequestException : BaseException
    {
        public BadRequestException(string? message, object? parameters = null) : base(HttpStatusCode.BadRequest, "BAD_REQUEST", message, parameters)
        {
        }
    }
}

