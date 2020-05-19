using System.Text.Json;

namespace JamaClient.Serialization
{
    public sealed class SerializationService : ISerializationService
    {
        private static readonly JsonSerializerOptions Options = CreateOptions();

        public static JsonSerializerOptions CreateOptions()
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

        public string Serialize<TValue>(TValue value)
        {
            return JsonSerializer.Serialize(value, Options);
        }

        public TValue Deserialize<TValue>(string json)
        {
            return JsonSerializer.Deserialize<TValue>(json, Options);
        }
    }
}
