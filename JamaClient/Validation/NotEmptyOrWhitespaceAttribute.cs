using System;
using System.ComponentModel.DataAnnotations;

namespace JamaClient.Validation
{
    // TODO: Rename to NotRequiredAttriobute for consistency (with the RequiredAttribute dissallowing white-space only 
    // strings by default)? Don't rename to stay consistent with the string.IsNullOrEmpty / IsNullOrWhitespace methods?
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class NotEmptyOrWhitespaceAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string stringValue)
            {
                return stringValue.Trim().Length > 0;
            }

            return true;
        }
    }
}
