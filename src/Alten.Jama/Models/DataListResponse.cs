using System.Collections.Generic;

namespace Alten.Jama.Models
{
    public sealed class DataListResponse<T> : MetaResponse
        where T : class
    {
        public Dictionary<string, Link> Links { get; set; }

        public Dictionary<string, Dictionary<string, object>> Linked { get; set; }

        public List<T> Data { get; set; }
    }
}
