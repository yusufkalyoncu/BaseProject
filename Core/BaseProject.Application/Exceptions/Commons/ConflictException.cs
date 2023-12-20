using System;
using System.Net;

namespace BaseProject.Application.Exceptions.Commons
{
    public class ConflictException : BaseException
    {
        public ConflictException(string? message, object? parameters = null) : base(HttpStatusCode.Conflict, "CONFLICT", message, parameters)
        {
        }
    }
}

