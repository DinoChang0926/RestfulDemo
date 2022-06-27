using Microsoft.Extensions.Logging;
using System;

namespace RestfulDemo.Exceptions
{
    public class HttpResponseException : Exception
    {
        private readonly ILogger<HttpResponseException> _logger;
        public HttpResponseException(ILogger<HttpResponseException> logger)
        {
            _logger = logger;
        }
        public HttpResponseException(int statusCode, object value = null)
        {
            (StatusCode, Value) = (statusCode, value);
            _logger.LogError(statusCode+" "+ value);
        }
          

        public int StatusCode { get; }

        public object Value { get; }
    }
}
