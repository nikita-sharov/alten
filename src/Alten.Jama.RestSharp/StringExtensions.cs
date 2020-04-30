using System.Linq;

namespace Alten.Jama
{
    public static class StringExtensions
    {
        public static bool IsEmptyOrWhiteSpace(this string value) => value.All(char.IsWhiteSpace);
    }
}
