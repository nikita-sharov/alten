using System;

namespace Alten.Jama
{
    // See: https://dev.jamasoftware.com/api/#auth
    public sealed class JamaOptions
    {
        public const int MaxResultsDefault = 20;
        public const int MaxResultsMax = 50;

        // See: https://community.jamasoftware.com/blogs/jason/2019/11/22/sunset-of-rest-api-latest-coming-in-may-2020
        public Uri BaseUrl { get; set; }
        
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
