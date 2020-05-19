using System;
using System.Net;

namespace GosuClient.Models
{
    public class CreateResponseMeta
    {
        public HttpStatusCode Status { get; set; }
        
        public DateTimeOffset Timestamp { get; set; }

        public Uri Location { get; set; }

        public int Id { get; set; }
    }
}
