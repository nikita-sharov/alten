using System;
using System.Collections.Generic;

namespace JamaClient.Models
{
    public sealed class FilterDataListWrapper
    {
        public List<Filter> Data { get; set; }

        public Dictionary<string, Link> Links { get; set; }

        public Dictionary<string, Dictionary<string, Object>> Linked { get; set; }

        public MetaListWrapper Meta { get; set; }
    }
}
