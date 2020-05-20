using System.Text.Json;

namespace Alten.Jama.Serialization
{
    public static class JsonSerializerOptionsFactory
    {
        public static JsonSerializerOptions Create()
        {
            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            options.Converters.Add(new DateTimeOffsetConverter());
            options.Converters.Add(new EnumConverterFactory());
            return options;
        }
    }
}
