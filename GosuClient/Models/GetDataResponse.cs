using System.Collections.Generic;

namespace GosuClient.Models
{
    public class GetDataResponse<T>
    {
        public Meta Meta { get; set; }

        public Dictionary<string, Link> Links { get; set; }

        public Dictionary<string, Dictionary<string, object>> Linked { get; set; }

        public T Data { get; set; }
    }
}
