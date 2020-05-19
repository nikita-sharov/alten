using System;
using System.Diagnostics;
using System.Web;

namespace JamaClient.Services
{
    public static class UriBuilderExtensions
    {
        public static void Skip(int count)
        {

        }

        public static void AddQueryParameter(this UriBuilder builder, string name, object value)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(name));
            Debug.Assert(value != null);

            if (!string.IsNullOrEmpty(builder.Query))
            {
                builder.Query += "&";
            }

            string encodedValue = HttpUtility.UrlEncode(value.ToString());
            builder.Query += $"{name}={encodedValue}";
        }
    }
}
