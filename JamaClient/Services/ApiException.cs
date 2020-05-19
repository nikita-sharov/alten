using System;
using System.Net;
using System.Runtime.Serialization;

namespace JamaClient.Services
{
    public class ApiException : Exception
    {
        public ApiException()
        {
        }

        public ApiException(string message) 
            : base(message)
        {
        }

        public ApiException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        protected ApiException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }

        public HttpStatusCode StatusCode { get; set; }

        public string ReasonPhrase { get; set; }
    }
}
