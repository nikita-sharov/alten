using System.Collections.Generic;

namespace JamaClient.Models
{
    public class DataListResponse<T> : MetaResponse
        where T : class
    {
        public Dictionary<string, Link> Links { get; set; }

        public Dictionary<string, Dictionary<string, object>> Linked { get; set; }

        public List<T> Data { get; set; }
    }
}
