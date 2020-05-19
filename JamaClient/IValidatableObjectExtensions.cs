using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace JamaClient
{
    public static class IValidatableObjectExtensions
    {
        public static bool IsValid(this IValidatableObject obj)
        {
            IEnumerable<ValidationResult> results = obj.Validate(validationContext: null);
            return !results.Any();
        }
    }
}
