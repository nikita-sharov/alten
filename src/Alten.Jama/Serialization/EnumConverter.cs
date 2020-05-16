using Humanizer;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Alten.Jama.Serialization
{
    public class EnumConverter<T> : JsonConverter<T> where T : Enum
    {
        private static readonly Type EnumType = typeof(T);

        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string upperSnakeCase = reader.GetString();
            string pascalCase = upperSnakeCase.ToLowerInvariant().Pascalize();

            // Ignore case because of "OK" being pascalized to "Ok"
            return (T)Enum.Parse(EnumType, pascalCase, ignoreCase: true);
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            string pascalCase = value.ToString();
            string upperSnakeCase = pascalCase.Underscore().ToUpperInvariant();
            writer.WriteStringValue(upperSnakeCase);
        }
    }
}
