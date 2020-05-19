using System;
using System.Net;

namespace JamaClient.Models
{
    public class MetaWrapper
    {
        public HttpStatusCode Status { get; set; }
        
        public DateTimeOffset Timestamp { get; set; }

        public string Message { get; set; }


    }
}
