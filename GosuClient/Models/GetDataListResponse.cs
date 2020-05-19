using System.Collections.Generic;

namespace GosuClient.Models
{
    public class GetDataListResponse<T>
    {
        public GetDataListMeta Meta { get; set; }

        public Dictionary<string, Link> Links { get; set; }

        public Dictionary<string, Dictionary<string, object>> Linked { get; set; }

        public List<T> Data { get; set; }
    }
}
