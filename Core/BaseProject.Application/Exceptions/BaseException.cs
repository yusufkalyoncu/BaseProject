using System;
using System.Net;

namespace BaseProject.Application.Exceptions
{
    public class BaseException : Exception
    {
        public BaseException(HttpStatusCode statusCode, string error, string? message, object? parameters = null) : base(message)
        {
            StatusCode = statusCode;
            Error = error;
            Parameters = parameters;
        }

        public HttpStatusCode StatusCode { get; set; }
        public string Error { get; set; }
        public object? Parameters { get; set; }
    }
}

