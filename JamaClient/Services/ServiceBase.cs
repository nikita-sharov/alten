using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace JamaClient.Services
{
    public abstract class ServiceBase
    {
        private const string BaseUrl = "";

        private const int MaxResultsDefault = 20;
        private const int MaxResultsMax = 50;

        protected ServiceBase(string resource) => Resource = resource;

        protected string Resource { get; private set; }

        protected string Endpoint => $"{BaseUrl}/{Resource}";

        protected Uri CreateRequestUri() =>
            CreateRequestUri(null, null, null, null);
        protected Uri CreateRequestUri(string resource) =>
            CreateRequestUri(resource, null, null, null);

        protected Uri CreateRequestUri(int id) =>
            CreateRequestUri(id.ToString(), null, null, null);

        protected Uri CreateRequestUri(int id, IEnumerable<string> include) =>
            CreateRequestUri(id.ToString(), null, null, null);

        protected Uri CreateRequestUri(int? startAt, int? maxResults) =>
            CreateRequestUri(null, startAt, maxResults, null);

        protected Uri CreateRequestUri(string resource, int? startAt, int? maxResults) =>
            CreateRequestUri(resource, startAt, maxResults, null);

        protected Uri CreateRequestUri(string resource, int? startAt, int? maxResults, IEnumerable<string> include)
        {
            var builder = new UriBuilder(Endpoint);

            if (resource != null)
            {
                builder.Path += $"/{resource}";
            }

            if (startAt.HasValue)
            {
                Debug.Assert((startAt >= 0) && (startAt < int.MaxValue));
                builder.AddQueryParameter(nameof(startAt), startAt);
            }

            if (maxResults.HasValue)
            {
                Debug.Assert((maxResults > 0) && (maxResults <= MaxResultsMax));
                if (maxResults != MaxResultsDefault)
                {
                    builder.AddQueryParameter(nameof(maxResults), maxResults);
                }
            }

            if (include != null)
            {
                foreach (var value in include)
                {
                    builder.AddQueryParameter(nameof(include), value);
                }
            }

            return builder.Uri;
        }
    }
}
