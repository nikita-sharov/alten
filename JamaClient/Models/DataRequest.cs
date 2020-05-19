using JamaClient.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JamaClient.Models
{
    public class DataRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Resource { get; set; }

        public ISet<string> Include { get; } = new HashSet<string>();

        // TODO: Validate here?
        public Uri ToRelativeUri()
        {
            var builder = BuildUriBuilder();
            return builder.Uri;
        }

        protected virtual UriBuilder BuildUriBuilder()
        {
            var builder = new UriBuilder
            {
                Path = Resource
            };

            foreach (string item in Include)
            {
                builder.AddQueryParameter(nameof(Include), item);
            }

            return builder;
        }
    }
}
