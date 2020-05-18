using System.Diagnostics.CodeAnalysis;

namespace Alten.Career.Models
{
    public sealed class JobApplicationAttachment
    {
        public int JobApplicationId { get; set; }

        public JobApplication JobApplication { get; set; }


        [SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "Reviewed")]
        public byte[] Content { get; set; }

        public string ContentType { get; set; }

        public string FileName { get; set; }
    }
}
