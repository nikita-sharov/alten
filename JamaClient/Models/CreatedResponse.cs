using System;
using System.Collections.Generic;

namespace JamaClient.Models
{
    // See: https://rest.jamasoftware.com/#datatype_CreatedResponse
    [Obsolete("Use MetaResponse instead.")]
    public class CreatedResponse
    {
        public int Status { get; set; }

        public string StatusReasonPhrase { get; set; }

        public PageInfo PageInfo { get; set; }

        public Dictionary<string, List<string>> Headers { get; set; }

        public string Location { get; set; }

        public int Id { get; set; }
    }   
}
