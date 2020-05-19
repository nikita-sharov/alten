using System;
using System.Collections.Generic;
using System.Text;

namespace GosuClient.Models
{
    public class PageInfo
    {
        public int StartIndex { get; set; }

        public int ResultCount { get; set; }

        public int TotalResults { get; set; }
    }
}
