using Humanizer;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Alten.Career.Helpers
{
    public static class DisplayAttributeHelper
    {
        public static string GetName(PropertyInfo property)
        {
            DisplayAttribute attribute = property.GetCustomAttribute<DisplayAttribute>();
            string displayName = attribute?.Name ?? property.Name.Humanize();
            if (IsRequired(property))
            {
                displayName += "*";
            }

            return displayName;
        }

        private static bool IsRequired(PropertyInfo property)
        {
            if (IsNullable(property.PropertyType))
            {
                return property.GetCustomAttribute<RequiredAttribute>() != null;
            }

            return false;
        }

        private static bool IsNullable(Type type)
        {
            if (type.IsValueType)
            {
                return Nullable.GetUnderlyingType(type) != null;
            }

            return true;
        }
    }
}
