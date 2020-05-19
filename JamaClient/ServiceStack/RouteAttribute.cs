using System;

namespace JamaClient.ServiceStack
{
    public class RouteAttribute : Attribute
    {
        public RouteAttribute(string path)
        {
            Path = path;
        }

        public string Path { get; private set; }
    }
}
