using System;
using System.Net;

namespace BaseProject.Application.Exceptions.Commons
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string? message, object? parameters = null) : base(HttpStatusCode.NotFound, "NOT_FOUND", message, parameters)
        {
        }
    }
}

