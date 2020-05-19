using System;
using System.Net;

namespace JamaClient.Models
{
    public sealed class MetaListWrapper
    {
        public HttpStatusCode Status { get; set; }

        public DateTimeOffset Timestamp { get; set; }

        public string Message { get; set; }

        public PageInfo PageInfo { get; set; }
    }
}