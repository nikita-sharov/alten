using System;
using System.ComponentModel.DataAnnotations;

namespace JamaClient.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class NotEmptyAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string stringValue)
            {
                return stringValue.Length > 0;
            }

            return true;
        }
    }
}
