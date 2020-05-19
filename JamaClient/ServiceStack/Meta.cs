using System;
using System.Net;

namespace JamaClient.ServiceStack
{
    public sealed class Meta
    {
        public HttpStatusCode Status { get; set; }

        public DateTimeOffset Timestamp { get; set; }
    }
}
