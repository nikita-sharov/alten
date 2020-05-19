using System;
using System.Collections.Generic;

namespace JamaClient.Models
{
    // See: https://rest.jamasoftware.com/#datatype_AbstractRestResponse
    [Obsolete("Use MetaResponse instead.")]
    public class AbstractRestResponse
    {
        public int Status { get; set; }

        public string StatusReasonPhrase { get; set; }

        public PageInfo PageInfo { get; set; }

        public Dictionary<string, List<string>> Headers { get; set; }
    }
}
