using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Alten.Jama.Serialization
{
    // See: https://dev.jamasoftware.com/cookbook/#date-format    
    public sealed class DateTimeOffsetConverter : JsonConverter<DateTimeOffset>
    {
        // See: https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings
        public static readonly string Format = "yyyy-MM-ddTHH:mm:ss.fffzz00";        
        public static readonly IFormatProvider FormatProvider = CultureInfo.InvariantCulture.DateTimeFormat;

        public override DateTimeOffset Read(
            ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)

        {
            var stringValue = reader.GetString();
            return DateTimeOffset.ParseExact(stringValue, Format, FormatProvider);
        }            

        public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
        {
            var stringValue = value.ToString(Format, FormatProvider);
            writer.WriteStringValue(stringValue);
        }
    }
}
