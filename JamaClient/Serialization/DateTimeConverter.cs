using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JamaClient.Serialization
{
    public sealed class DateTimeConverter : JsonConverter<DateTime>
    {
        private static readonly string Format = "yyyy-MM-dd";
        private static readonly IFormatProvider FormatProvider = CultureInfo.InvariantCulture.DateTimeFormat;

        public static string ToShortDateString(DateTime value) => value.ToString(Format, FormatProvider);

        public static DateTime FromShortDateString(string value) => DateTime.ParseExact(value, Format, FormatProvider);

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var stringValue = reader.GetString();
            return FromShortDateString(stringValue);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            var stringValue = ToShortDateString(value);
            writer.WriteStringValue(stringValue);
        }
    }
}
