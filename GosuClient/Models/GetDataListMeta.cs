using System;
using System.Net;

namespace GosuClient.Models
{
    public class GetDataListMeta
    {
        public HttpStatusCode Status { get; set; }
        
        public DateTimeOffset Timestamp { get; set; }

        public PageInfo PageInfo { get; set; }
    }
}
