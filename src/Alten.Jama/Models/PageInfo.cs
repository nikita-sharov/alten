namespace Alten.Jama.Models
{
    // See: https://rest.jamasoftware.com/#datatype_PageInfo
    public sealed class PageInfo
    {
        public int StartIndex { get; set; }

        public int ResultCount { get; set; }

        public int TotalResults { get; set; }
    }
}
