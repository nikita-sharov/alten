using System.Collections.Generic;

namespace Alten.Jama.Models
{
    public class DataResponse<T> : MetaResponse 
        where T : class
    {
        public Dictionary<string, Link> Links { get; set; }

        public Dictionary<string, Dictionary<string, object>> Linked { get; set; }

        public T Data { get; set; }
    }
}
