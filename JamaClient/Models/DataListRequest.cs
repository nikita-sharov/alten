using JamaClient.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace JamaClient.Models
{
    public class DataListRequest : DataRequest, IValidatableObject
    {
        private const int MaxResultsMax = 50;
        private const int MaxResultsDefault = 20;

        // TODO: Determine max value (int.MaxValue - 2, and so on).
        [Range(0, int.MaxValue - 1)]
        public int StartAt { get; set; }

        [Range(1, MaxResultsMax)]
        public int MaxResults { get; set; } = MaxResultsDefault;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return Enumerable.Empty<ValidationResult>();
        }

        protected override UriBuilder BuildUriBuilder()
        {
            var builder = base.BuildUriBuilder();
            
            if (StartAt > 0)
            {
                builder.AddQueryParameter(nameof(StartAt), StartAt);
            }

            if (MaxResults != MaxResultsDefault)
            {
                builder.AddQueryParameter(nameof(MaxResults), MaxResults);
            }

            return builder;
        }
    }
}
