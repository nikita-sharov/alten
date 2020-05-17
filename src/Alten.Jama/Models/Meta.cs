using System;
using System.Net;

namespace Alten.Jama.Models
{
    // See: https://rest.jamasoftware.com/#datatype_MetaWrapper
    // See: https://rest.jamasoftware.com/#datatype_MetaListWrapper    
    public sealed class Meta
    {
        public HttpStatusCode Status { get; set; }
        
        public DateTimeOffset Timestamp { get; set; }

        public string Message { get; set; }

        public PageInfo PageInfo { get; set; }

        public string Location { get; set; }

        public int? Id { get; set; }
    }
}
