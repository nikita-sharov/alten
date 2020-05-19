using System;
using System.Net;

namespace GosuClient.Models
{
    public class Meta
    {
        public HttpStatusCode Status { get; set; }
        
        public DateTimeOffset Timestamp { get; set; }
    }
}
