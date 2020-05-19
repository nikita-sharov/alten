using System.Linq;

namespace JamaClient.Services
{
    public static class StringExtensions
    {
        public static bool IsEmptyOrWhiteSpace(this string value) => value.All(char.IsWhiteSpace);
    }
}
