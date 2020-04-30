using RestSharp;
using System.Diagnostics;

namespace Alten.Jama
{
    public static class RestRequestFactory
    {
        public static IRestRequest Create(string resource, params string[] include) => 
            Create(resource, null, null, include);

        public static IRestRequest Create(string resource, int? startAt, int? maxResults, params string[] include)
        {
            var request = new RestRequest(resource);

            if (startAt.HasValue)
            {
                Debug.Assert(startAt >= 0);
                if (startAt > 0)
                {
                    request.AddParameter(nameof(startAt), startAt);
                }
            }

            if (maxResults.HasValue)
            {
                Debug.Assert((maxResults > 0) && (maxResults <= JamaOptions.MaxResultsMax));
                if (maxResults != JamaOptions.MaxResultsDefault)
                {
                    request.AddParameter(nameof(maxResults), maxResults);
                }
            }

            if (include != null)
            {
                foreach (string value in include)
                {
                    request.AddParameter(nameof(include), value);
                }
            }

            return request;
        }
    }
}
